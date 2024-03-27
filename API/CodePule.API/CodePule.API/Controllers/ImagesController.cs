
using CodePule.API.Modules.Domain;
using CodePule.API.Modules.DTO;
using CodePule.API.Repositories.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImageRepository imageRepository;

        public ImagesController(ImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //Post: {apibaseurl}/api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if(ModelState.IsValid) 
            {
                //File upload
                var blogImage = new BlogImage
                {
                    FileExtention = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCreated = DateTime.Now,
                };

                blogImage = await imageRepository.Upload(file, blogImage);

                //Convert domain model to dto

                var response = new BlogImageDto
                {
                    Id = blogImage.Id,
                    Title = blogImage.Title,
                    DateCreated = blogImage.DateCreated,
                    FileExtention = blogImage.FileExtention,
                    FileName = blogImage.FileName,
                    Url = blogImage.Url,
                };

                return Ok(blogImage);
            }

            return BadRequest(ModelState);


        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if(!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");

            }

            if(file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }
    }
}
