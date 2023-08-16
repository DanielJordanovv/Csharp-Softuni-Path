namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchersWithTrucks = context.Despatchers
            .Where(d => d.Trucks.Any())
            .ToArray()
            .Select(d => new ExportDespatchersDto()
            {
                TruckCount = d.Trucks.Count(),
                DespatcherName = d.Name,
                Trucks = d.Trucks
                    .Select(t => new ExportTruckXml()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
            })
            .OrderByDescending(d => d.TruckCount)
            .ThenBy(d => d.DespatcherName)
            .ToArray();

            return Serialize<ExportDespatchersDto[]>(despatchersWithTrucks, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsWithTrucks = context.Clients
             .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
             .ToArray()
             .Select(c => new ExportClientsDto()
             {
                 Name = c.Name,
                 Trucks = c.ClientsTrucks
                     .Where(t => t.Truck.TankCapacity >= capacity)
                     .Select(t => new TrucksJson()
                     {
                         RegistrationNumber = t.Truck.RegistrationNumber,
                         VinNumber = t.Truck.VinNumber,
                         TankCapacity = t.Truck.TankCapacity,
                         CargoCapacity = t.Truck.CargoCapacity,
                         CategoryType = t.Truck.CategoryType.ToString(),
                         MakeType = t.Truck.MakeType.ToString()
                     })
                     .OrderBy(t => t.MakeType)
                     .ThenByDescending(t => t.CargoCapacity)
                     .ToArray()
             })
             .OrderByDescending(c => c.Trucks.Count())
             .ThenBy(c => c.Name)
             .Take(10)
             .ToArray();

            return JsonConvert.SerializeObject(clientsWithTrucks, Formatting.Indented);
        }
        private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            StringBuilder sb = new StringBuilder();
            using var write = new StringWriter(sb);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

            return sb.ToString();
        }
    }
}
