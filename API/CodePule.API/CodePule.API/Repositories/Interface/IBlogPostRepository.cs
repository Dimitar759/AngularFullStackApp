using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;

namespace CodePule.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetByIdAsync(Guid id);
    }
}
