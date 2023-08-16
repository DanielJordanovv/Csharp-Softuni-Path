using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }
        [XmlArray("Trucks")]
        public TrucksXml[] Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class TrucksXml
    {
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; }
        [MinLength(17)]
        [MaxLength(17)]
        public string VinNumber { get; set; }
        [Range(typeof(int), "950", "1420")]
        public int TankCapacity { get; set; }
        [Range(typeof(int), "5000", "29000")]
        public int CargoCapacity { get; set; }
        [Required]
        public int CategoryType { get; set; }
        [Required]
        public int MakeType { get; set; }
    }

}
