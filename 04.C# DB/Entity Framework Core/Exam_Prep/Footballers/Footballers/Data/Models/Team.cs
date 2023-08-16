﻿using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\s\.-]{3,40}$")]
        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }
        [Required]
        public int Trophies { get; set; }
        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
