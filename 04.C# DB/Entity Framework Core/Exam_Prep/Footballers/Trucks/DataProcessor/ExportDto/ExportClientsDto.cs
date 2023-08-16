using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto
{
    public class ExportClientsDto
    {
        public string Name { get; set; }
        public TrucksJson[] Trucks { get; set; }
    }
    public class TrucksJson
    {
        [JsonProperty("TruckRegistrationNumber")]
        public string RegistrationNumber { get; set; }
        public string VinNumber { get; set; }
        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public string CategoryType { get; set; }
        public string MakeType { get; set; }
    }

}
