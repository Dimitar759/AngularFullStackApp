using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePule.API.Modules.DTO
{
    public class CreateCategoryRequestDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
