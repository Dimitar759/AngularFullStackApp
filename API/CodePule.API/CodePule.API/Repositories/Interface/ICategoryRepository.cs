using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;
using Microsoft.EntityFrameworkCore;

namespace CodePule.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync(string? query = null);

        Task<Category?> GetById(Guid id);

        Task <Category?> UpdateAsync (Category category);

        Task<Category?> DeleteAsync(Guid id);

    }
}
