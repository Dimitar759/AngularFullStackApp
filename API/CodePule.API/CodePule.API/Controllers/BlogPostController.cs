using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;
using CodePule.API.Repositories.Implementation;
using CodePule.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        //Post: {apibaseurl}/api/blogposts
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody]CreateBlogPostRequestDto request)
        {
            //Convert from dto to domain model

            var blogPost = new BlogPost
            {
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                PublishedData = request.PublishedData,
                ShortDescription= request.ShortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle
            };
            await blogPostRepository.CreateAsync(blogPost);

            //Convert domain model to dto
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                PublishedData = request.PublishedData,
                ShortDescription = request.ShortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle
            };

            return Ok(response);
        }
    }
}
