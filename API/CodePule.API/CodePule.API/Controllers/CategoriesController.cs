using CodePule.API.Data;
using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;
using CodePule.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePule.API.Controllers
{
    // https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public Categories(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //map dto to domain model

            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
            //afdasfasdf
            await categoryRepository.CreateAsync(category);
            //Domain model to dto
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}
