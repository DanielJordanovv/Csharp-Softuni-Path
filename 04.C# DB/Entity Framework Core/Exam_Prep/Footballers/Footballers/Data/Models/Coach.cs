using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers = new HashSet<Footballer>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Nationality { get; set; }
        public virtual ICollection<Footballer> Footballers { get; set; }
    }
}
