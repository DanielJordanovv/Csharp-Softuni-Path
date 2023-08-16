using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Entities;
using SoftUniBazar.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Data.ValidationConstants.Ad;

namespace SoftUniBazar.ViewModels.Ad
{
    public class AdAddViewModel
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
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryAllViewModel> Categories = new List<CategoryAllViewModel>();
    }
}
