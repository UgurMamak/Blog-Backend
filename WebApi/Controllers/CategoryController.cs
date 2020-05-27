using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Core.Extensions;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Service katmanı yazıldıysa burada serviceler ile apimiz yönlendirilebilecek.

        //Operasyonları yazarken bussines'da Dataaccess kullandıysak burada da bussiniess kullanacağız
       private ICategoryService _categoryService;//service enjeksiyonu yapıldı.
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        [HttpGet("getall")]
        //[Authorize()] //Her login olan bu operasyonu kullanabilir demek.
        //[Authorize()] //Her login olan bu operasyonu kullanabilir demek.
       // [Authorize(Roles ="SystemAdmin")]//role verme şekli
        public IActionResult GetList()
        {
            ///User.ClaimRoles(); //Kulanıcıya ait rolleri getirir.
            //(Core katmanındaki extensions dizininde bulunan ClaimsPricipalExtensions metotdun da yazıldı.)

            var result = _categoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return  BadRequest(result.Message);
        }
        /*
        //CategoryId'ye göre listeleme işlemi
        [HttpGet("getbyid")]
        public IActionResult GetById(string categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        */
        //CategoryId'ye göre listeleme işlemi
        [HttpGet("getbyid")]
        public IActionResult GetById(string categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            var cat = new CategoryListDto { 
                CategoryName=result.Data.CategoryName,
                Id=result.Data.Id
            };
            if (result.Success)
            {
                return Ok(cat);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]//++++
        public IActionResult Add(Category category)
        {
            var categoryExists = _categoryService.CategoryExists(category.CategoryName);            
            if (!categoryExists.Success)
            {
                return BadRequest(categoryExists.Message);
            }

            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }





   


    }
}