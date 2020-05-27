using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IWebHostEnvironment _environment;



        public UserController(IUserService userService,IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _environment = webHostEnvironment;
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

       //  [Authorize(Roles ="user")]//role verme şekli
         //[Authorize(Roles ="user")]//role verme şekli
        [HttpGet("getbyuserId")]
        public IActionResult GetByUserId(string userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return Ok(result.Message);
        }


        [HttpPost("update")]
       
        public async Task<IActionResult> Update([FromForm] UserUpdateDto userUpdateDto)
        {
          var newImageName = $"{ Guid.NewGuid()}.jpg";
            userUpdateDto.ImageName = newImageName;

            var update = _userService.Update(userUpdateDto);
            if(update.Success)
            {
                if(userUpdateDto.Image!=null)
                {
                    var resimler = Path.Combine(_environment.WebRootPath, "userImage");//dizin bilgisi
                    System.IO.File.Delete(resimler + "\\" + userUpdateDto.ImageName);//eski resim silinir.

                    using (var fileStream = new FileStream(Path.Combine(resimler, newImageName), FileMode.Create))
                    { await userUpdateDto.Image.CopyToAsync(fileStream);}
                    
                }
                return Ok(update.Message);
            }            
            return BadRequest(update.Message);
        }
    }
}