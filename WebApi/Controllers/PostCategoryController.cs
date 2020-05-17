using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostCategoryController : ControllerBase
    {
        private IPostCategoryService _postCategoryService;
        public PostCategoryController(IPostCategoryService postCategoryService)
        {
            _postCategoryService = postCategoryService;
        }

        //CategoryId'ye göre listeleme işlemi
        [HttpGet("getbyid")]//+++
        public IActionResult GetById(string postCategoryId)
        {
            var result = _postCategoryService.GetById(postCategoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbycategory")]//+++
        public IActionResult GetListByCategory(string categoryId)
        {
            //CategoryId'ye göre postları listelemek için
            var result = _postCategoryService.GetListByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(PostCategory postCategory)
        {
            var result = _postCategoryService.Update(postCategory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
//*******************************************************************************************
       
        
        [HttpPost("add")]//+++
        public IActionResult Add(PostCategoryCreateDto postCategoryCreateDto)
        {
            var result = _postCategoryService.Add(postCategoryCreateDto);
            if (result.Success) { return Ok(result.Message); }
            return BadRequest(result.Message);
        }
        


        [HttpPost("delete")]//
        public IActionResult Delete(PostCategory postCategory)
        {
            var result = _postCategoryService.Delete(postCategory);
            if (result.Success) { return Ok(result.Message); }
            return BadRequest(result.Message);
        }


        [HttpGet("getall")] //tüm postları listeleme +++
        public IActionResult GetAll()
        {
            var result = _postCategoryService.GetAll();
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }



        [HttpGet("getall2")] //tüm postları listeleme +++
        public IActionResult GetAll2()
        {
            var result = _postCategoryService.GetAll2();
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }



        [HttpGet("getbycategoryId")]//seçilen kategoriye göre listeleme +++
        public IActionResult GetByCategoryId(string categoryId)
        {
            var result = _postCategoryService.GetByCategoryId(categoryId);
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserId")] //postu yazan kişiye göre listeleme +++
        public IActionResult GetByUserId(string userId)
        {
            var result = _postCategoryService.GetByUserId(userId);
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }




    }
}