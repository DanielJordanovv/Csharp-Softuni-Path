using SoftUniBazar.ViewModels.Category;

namespace SoftUniBazar.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryAllViewModel>> AllAsync();
    }
}
