using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachWithFootballers
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public FootballersXml[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class FootballersXml
    {
        [XmlElement("Name")]
        public string FootballerName { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }
    }
}

