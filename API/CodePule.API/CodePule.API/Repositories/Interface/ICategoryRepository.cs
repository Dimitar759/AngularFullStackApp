using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;
using Microsoft.EntityFrameworkCore;

namespace CodePule.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync(
            string? query = null, 
            string? sortBy = null, 
            string? sortDirection = null, 
            int? pagenumber = 1, 
            int? pageSize = 100);

        Task<Category?> GetById(Guid id);

        Task <Category?> UpdateAsync (Category category);

        Task<Category?> DeleteAsync(Guid id);

        Task<int> GetCount();
    }
}
