using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; }
        [MinLength(17)]
        [MaxLength(17)]
        public string VinNumber { get; set; }
        [Range(typeof(int),"950" , "1420")]
        public int TankCapacity { get; set; }
        [Range(typeof(int),"5000" , "29000")]
        public int CargoCapacity { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }
        [Required]
        public MakeType MakeType { get; set; }
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }
        public virtual Despatcher Despatcher { get; set; }
        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
