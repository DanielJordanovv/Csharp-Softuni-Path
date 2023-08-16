using Microsoft.AspNetCore.Identity;

namespace SoftUniBazar.ViewModels.Ad
{
    public class AdCartViewModel
    {
        public string BuyerId { get; set; } = null!;
        public virtual IdentityUser Buyer { get; set; } = null!;
        public ICollection<AdAllViewModel> Ads { get; set; } = new HashSet<AdAllViewModel>();
    }
}
