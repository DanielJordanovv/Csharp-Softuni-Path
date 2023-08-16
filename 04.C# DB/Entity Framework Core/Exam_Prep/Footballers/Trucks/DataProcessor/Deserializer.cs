namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDespatchersDto[] despatchersDtos = Deserialize<ImportDespatchersDto[]>(xmlString, "Despatchers");

            foreach (ImportDespatchersDto despatcher in despatchersDtos)
            {
                if (!IsValid(despatcher))
                {
                    sb.Append(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(despatcher.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher inputDesaptcher = new Despatcher()
                {
                    Name = despatcher.Name,
                    Position = despatcher.Position
                };
                foreach (var truck in despatcher.Trucks)
                {
                    if (!IsValid(truck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Truck inportTruck = new Truck()
                    {
                        RegistrationNumber = truck.RegistrationNumber,
                        VinNumber = truck.VinNumber,
                        TankCapacity = truck.TankCapacity,
                        CargoCapacity = truck.CargoCapacity,
                        CategoryType = (CategoryType)truck.CategoryType,
                        MakeType = (MakeType)truck.MakeType,
                    };
                    inputDesaptcher.Trucks.Add(inportTruck);
                }
                context.Despatchers.Add(inputDesaptcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, inputDesaptcher.Name, inputDesaptcher.Trucks.Count));
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportClientsDto[] clients = JsonConvert.DeserializeObject<ImportClientsDto[]>(jsonString);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var clientDto in clients)
            {
                if (!IsValid(clientDto) || string.IsNullOrEmpty(clientDto.Nationality) || clientDto.Type == "usual")
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.TruckIds.Distinct())
                {
                    if (!context.Trucks.Any(t => t.Id == truckId))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck()
                    {
                        Client = client,
                        Truck = context.Trucks.FirstOrDefault(t => t.Id == truckId)
                    });
                }

                context.Clients.Add(client);
                context.SaveChanges();
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedClient, client.Name,
                    client.ClientsTrucks.Count));
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }
    }
}