using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s\.-]{3,40}$")]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }
        [Required]
        public int Trophies { get; set; }
        [JsonProperty("Footballers")]
        public int[] FootballersIds { get; set; }
    }
}
