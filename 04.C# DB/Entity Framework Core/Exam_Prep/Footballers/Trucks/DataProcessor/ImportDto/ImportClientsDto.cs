﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientsDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Nationality { get; set; }
        [Required]
        public string Type { get; set; }
        [JsonProperty("Trucks")]
        public int[] TruckIds { get; set; }
    }
}
