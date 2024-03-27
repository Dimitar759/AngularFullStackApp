using CodePule.API.Modules.Domain;

namespace CodePule.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task <BlogImage>Upload(IFormFile file, BlogImage blogImage);
    }
}
