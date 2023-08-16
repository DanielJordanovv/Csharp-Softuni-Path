using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Data.ValidationConstants.Ad;

namespace SoftUniBazar.Data.Entities
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [Column(TypeName = AdPriceColumnType)]
        public decimal Price { get; set; }
        [ForeignKey(nameof(Owner))]
        [Required]
        public string OwnerId { get; set; } = null!;
        [Required]
        public virtual IdentityUser Owner { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public DateTime CreatedOn { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; } = null!;
    }

}
