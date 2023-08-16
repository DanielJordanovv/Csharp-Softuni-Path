using SoftUniBazar.Data.Entities;
using SoftUniBazar.ViewModels.Ad;

namespace SoftUniBazar.Services.Interfaces
{
    public interface IAdService
    {
        Task<ICollection<AdAllViewModel>> AllAsync();
        Task AddAsync(AdAddViewModel model, string id);
        Task EditAsync(int id, AdEditViewModel model);
        Task<Ad> GetAdAsync(int id);
        Task<AdCartViewModel> CartAsync(string id);
        Task AddToCart(string userId, int id);
        Task RemoveFromCart(string userId, int id);
    }
}
