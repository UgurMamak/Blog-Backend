using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        private readonly IWebHostEnvironment _environment;
        public PostController(IPostService postService, IWebHostEnvironment environment)
        {
            _postService = postService;
            _environment = environment;
        }


        /*
        [HttpGet("getdeneme")]
        public IActionResult GetListDeneme()
        {
            var result = _postService.GetListDeneme();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        */


        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _postService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        //CategoryId'ye göre listeleme işlemi
        [HttpGet("getbyid")]
        public IActionResult GetById(string postId)
        {
            var result = _postService.GetById(postId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        /*
        [HttpPost("add")]
        public IActionResult Add(Post post)
        {
            var result = _postService.Add(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        */

        [HttpPost("update")]
        public IActionResult Update(Post post)
        {
            var result = _postService.Update(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Post post)
        {
            var result = _postService.Delete(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }



        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm]PostCreateDto postCreateDto)
        {
            if(postCreateDto.Image==null)
            {
                return BadRequest("Resim Eklenmedi");
            }

            string Id = Guid.NewGuid().ToString();//resimlere guid Id şeklinde isim ataması yaptım.
            var resimler = Path.Combine(_environment.WebRootPath, "postImage");//dizin bilgisi
            string imageName = $"{Id}.jpg";//Db ye kaydedilecek olan resimlerin ismi
          
            var result = _postService.Add(postCreateDto,imageName);
            if (result.Success)
            {
                if (postCreateDto.Image.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                    {
                        await postCreateDto.Image.CopyToAsync(fileStream);
                    }
                }
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }




    }
}