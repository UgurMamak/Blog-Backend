using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private IUserService _userService;
     //private readonly   IWebHostEnvironment _environment;
        private readonly IHostingEnvironment _environment;

       // IHostingEnvironment
        public UserController(IUserService userService, IHostingEnvironment environment)
        {
            _userService = userService;
            _environment = environment;
        }

        
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _userService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("uploadfile")]
        public async Task<ActionResult> UploadFile(FIleUploadAPI image,string deger)
        {
            /*
            if(image==null)
            {
                return BadRequest("burada");
                
            }
            */
            var resimler = Path.Combine(_environment.WebRootPath, "img");
            var imageName = "firstImage.jpg";
            if (image.files.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                {
                    await image.files.CopyToAsync(fileStream);
                }
            }
            //apiFile.ResimYolu = apiFile.ResimDosyasi.FileName;

            return Ok("oldu");
        }
    }

    public class FIleUploadAPI
    {
        public IFormFile files { get; set; }
    }
}