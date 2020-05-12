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


        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _postCategoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        //CategoryId'ye göre listeleme işlemi
        [HttpGet("getbyid")]
        public IActionResult GetById(string postCategoryId)
        {
            var result = _postCategoryService.GetById(postCategoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbycategory")]
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
        /*
        [HttpPost("add")]
        public IActionResult Add(PostCategory postCategory)
        {
            var result = _postCategoryService.Add(postCategory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        */

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

        [HttpPost("delete")]
        public IActionResult Delete(PostCategory postCategory)
        {
            var result = _postCategoryService.Delete(postCategory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        [HttpPost("add")]
        public IActionResult Add(PostCategoryCreateDto postCategoryCreateDto)
        {
            var result = _postCategoryService.Add(postCategoryCreateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



    }
}