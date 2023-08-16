namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coachesWithTheirFootballers = context.Coaches
            .Where(c => c.Footballers.Any())
            .ToArray()
            .Select(c => new ExportCoachWithFootballers()
            {
                FootballersCount = c.Footballers.Count,
                CoachName = c.Name,
                Footballers = c.Footballers
                    .Select(f => new FootballersXml()
                    {
                        FootballerName = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .OrderBy(f => f.FootballerName)
                    .ToArray()
            })
            .OrderByDescending(c => c.FootballersCount)
            .ThenBy(c => c.CoachName)
            .ToArray();

            return Serialize<ExportCoachWithFootballers[]>(coachesWithTheirFootballers, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithMostFootballers = context.Teams
            .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
            .ToArray()
            .Select(t => new ExportTeamsWihMostFootballersDto()
            {
                Name = t.Name,
                Footballers = t.TeamsFootballers
                    .Where(fb => fb.Footballer.ContractStartDate >= date)
                    .OrderByDescending(fb => fb.Footballer.ContractEndDate)
                    .ThenBy(fb => fb.Footballer.Name)
                    .Select(fb => new FootballersJson()
                    {
                        FootballerName = fb.Footballer.Name,
                        ContractStartDate = fb.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = fb.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = fb.Footballer.BestSkillType.ToString(),
                        PositionType = fb.Footballer.PositionType.ToString()
                    })
                    .ToArray()
            })
            .OrderByDescending(t => t.Footballers.Count())
            .ThenBy(t => t.Name)
            .Take(5)
            .ToArray();

            return JsonConvert.SerializeObject(teamsWithMostFootballers, Formatting.Indented);
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
