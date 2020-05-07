using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        // IHostingEnvironment
        public DenemeController(IWebHostEnvironment environment)
       {

            _environment = environment;
        }
        
        [HttpPost("uploadfile3")]
        //  [Produces("application/json")]
        public async Task< IActionResult> UploadFile3([FromForm] IFormFile image)
        {
            string Id = Guid.NewGuid().ToString();

            if (image == null)
            {
                return BadRequest("burada");

            }
            Random a = new Random();
            int b = a.Next(1, 100);

            var resimler = Path.Combine(_environment.WebRootPath, "img");
            var imageName = $"{Id}.jpg";
                
            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                {
                   await image.CopyToAsync(fileStream);
                }
            }
            //apiFile.ResimYolu = apiFile.ResimDosyasi.FileName;

            //return BadRequest();
            return Ok();
        }





    }



    public class FIleUploadAPI2
    {
        public IFormFile files { get; set; }
    }

    public class Bilgiler
    {
        public string ad { get; set; }
        public string soyad  { get; set; }

    }


}