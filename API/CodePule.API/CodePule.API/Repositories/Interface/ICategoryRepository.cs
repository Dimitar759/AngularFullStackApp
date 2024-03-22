using CodePule.API.Modules.Domain;

namespace CodePule.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();

    }
}
