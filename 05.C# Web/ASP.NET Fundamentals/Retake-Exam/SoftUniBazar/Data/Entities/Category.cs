using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.ValidationConstants.Category;

namespace SoftUniBazar.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Ad> Ads { get; set; }
    }
}
