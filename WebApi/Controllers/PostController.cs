using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostDtos;
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
        private IPostCategoryService _postCategoryService;
        public PostController(IPostService postService, IWebHostEnvironment environment, IPostCategoryService postCategoryService)
        {
            _postService = postService;
            _environment = environment;
            _postCategoryService = postCategoryService;
        }

        [HttpGet("getlist")]
        public IActionResult Getlist()
        {
            var result = _postService.GetList();
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }

        //*******************************************************************************************
        [HttpPost("add")]//+++
        public async Task<IActionResult> Add([FromForm]PostCreateDto postCreateDto)
        {
            if (string.IsNullOrEmpty(postCreateDto.CategoryId)) return BadRequest("Kategori Seçmediniz.");
            if (postCreateDto.Image == null) { return BadRequest("Resim Eklenmedi"); }

            string Id = Guid.NewGuid().ToString();//resimlere guid Id şeklinde isim ataması yaptım.
            var resimler = Path.Combine(_environment.WebRootPath, "postImage");//dizin bilgisi
            string imageName = $"{Id}.jpg";//Db ye kaydedilecek olan resimlerin ismi

            var result = _postService.Add(postCreateDto, imageName); //post ekleme işlemi

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

        [HttpGet("getbypostId")]//+++
        public IActionResult GetByPostId(string postId)
        {
            var result = _postService.GetByPostId(postId);
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Post post)
        {
            var result = _postService.Delete(post);
            if (result.Success) { return Ok(result.Message); }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] PostUpdateDto post)
        {
            var result = _postService.Update(post);
            if (result.Success) { return Ok(result.Message); }
            return BadRequest(result.Message);
        }



    }
}