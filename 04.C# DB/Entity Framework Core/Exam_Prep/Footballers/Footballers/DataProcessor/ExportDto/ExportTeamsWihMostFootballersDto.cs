namespace Footballers.DataProcessor.ExportDto
{
    public class ExportTeamsWihMostFootballersDto
    {
        public string Name { get; set; }
        public FootballersJson[] Footballers { get; set; }
    }
    public class FootballersJson
    {
        public string FootballerName { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public string PositionType { get; set; }
        public string BestSkillType { get; set; }
    }

}
