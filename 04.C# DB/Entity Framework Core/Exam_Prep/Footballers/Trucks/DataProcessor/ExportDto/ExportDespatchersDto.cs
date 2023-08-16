using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatchersDto
    {
        public int TruckCount { get; set; }
        public string DespatcherName { get; set; }
        public ExportTruckXml[] Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class ExportTruckXml
    {
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
    }
}
