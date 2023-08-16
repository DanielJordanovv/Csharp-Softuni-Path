using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Entities
{
    public class AdBuyer
    {
        [ForeignKey(nameof(Buyer))]
        [Required]
        public string BuyerId { get; set; } = null!;
        public virtual IdentityUser Buyer { get; set; } = null!;
        [ForeignKey(nameof(Ad))]
        [Required]
        public int AdId { get; set; }
        public virtual Ad Ad { get; set; } = null!;
    }
}
