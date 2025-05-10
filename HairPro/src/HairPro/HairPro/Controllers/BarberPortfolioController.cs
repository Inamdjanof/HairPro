using HairPro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HairPro.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class BarberPortfolioController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public BarberPortfolioController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadDto fileUploadDto)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
                return BadRequest("Fayl tanlanmagan!");

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(fileUploadDto.File.FileName)}";
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileUploadDto.File.CopyToAsync(stream);
            }

            var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(new { FilePath = fileUrl });
        }



    }




}
