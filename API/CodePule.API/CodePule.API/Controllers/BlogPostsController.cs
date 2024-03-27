using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;
using CodePule.API.Repositories.Implementation;
using CodePule.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CodePule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
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
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetById(categoryGuid);

                if (existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }
            blogPost = await blogPostRepository.CreateAsync(blogPost);

            //Convert domain model to dto
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedData = blogPost.PublishedData,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle

                }).ToList()

            };

            return Ok(response);
        }

        //Get: {apibaseurl/api/blogposts
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetAllAsync();

            //convert domain model to dto

            var response = new List<BlogPostDto>();
            foreach (var blogPost in blogPosts)
            {
                response.Add(new BlogPostDto
                {
                    Id = blogPost.Id,
                    Author = blogPost.Author,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    IsVisible = blogPost.IsVisible,
                    PublishedData = blogPost.PublishedData,
                    ShortDescription = blogPost.ShortDescription,
                    Title = blogPost.Title,
                    UrlHandle = blogPost.UrlHandle,
                    Categories = blogPost.Categories.Select(x => new CategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UrlHandle = x.UrlHandle

                    }).ToList()
                });
            }

            return Ok(response);
        }

        //Get: {apibaseurl}/api/plogposts/id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute]Guid id)
        {
            //Get the blogpost from repo
            var blogPost = await blogPostRepository.GetByIdAsync(id);

            if(blogPost == null)
            {
                return NotFound();
            }

            //ConvertToDto
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedData = blogPost.PublishedData,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle

                }).ToList(),
            };

            return Ok(response);
        }

        //Put: {apibaseurl}/api/blogposts/{id}
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, UpdateBlogPostRequestDto request)
        {
            //Convert dto to domain model
            var blogPost = new BlogPost
            {
                Id = id,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                PublishedData = request.PublishedData,
                ShortDescription = request.ShortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetById(categoryGuid);

                if(existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }

            //Call repository to update blogpost domain model
            var updatedBlogPost = await blogPostRepository.UpdateAsync(blogPost);

            if(updatedBlogPost == null)
            {
                return NotFound();
            }

            var response = new BlogPostDto
            {

                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedData = blogPost.PublishedData,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle

                }).ToList()
            };

            return Ok(response);

        }

    }
}
