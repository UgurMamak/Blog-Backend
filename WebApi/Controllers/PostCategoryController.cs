using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Authorization;
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

            if (result.Success) {
                var sonuc = result.Data.Where(w=>w.IsActive==true && w.IsDeleted==false);
                return Ok(sonuc); 
            }
            return BadRequest(result.Message);
        }

        [HttpGet("popularpost")] //en çoık like alan postları listelemek için
        public IActionResult GetPopularPost()
        {
            var result = _postCategoryService.GetAll2();
            var sonuc = result.Data.OrderByDescending(o=>o.LikeNumber).Where(w => w.IsActive == true && w.IsDeleted == false).Take(3).ToList();
            if (result.Success) { return Ok(sonuc); }
            return BadRequest(result.Message);
        }

      

        [HttpGet("confirmpost")] //is activeleri false olan postlarılistelemek için yazıldı.
        public IActionResult GetAdminConfirmpost()
        {
            var result = _postCategoryService.GetAll2();
            var sonuc = result.Data.OrderByDescending(o => o.LikeNumber).Where(w=>w.IsActive==false && w.IsDeleted==false);
            if (result.Success) { return Ok(sonuc); }
            return BadRequest(result.Message);
        }



        [HttpGet("getbycategoryId")]//seçilen kategoriye göre listeleme +++
        public IActionResult GetByCategoryId(string categoryId) 
        {
            var result = _postCategoryService.GetByCategoryId(categoryId);
            if (result.Success) { var sonuc = result.Data.Where(w => w.IsActive == true && w.IsDeleted==false); 
                return Ok(sonuc); }
            return BadRequest(result.Message);
        }


        //Kullanıcının onaylanmış postlarını listeler.
        [HttpGet("getbyuserId")] //postu yazan kişiye göre listeleme +++
        public IActionResult GetByUserId(string userId)
        {
            var result = _postCategoryService.GetByUserId(userId);
            if (result.Success) { var sonuc = result.Data.Where(w => w.IsActive == true && w.IsDeleted==false); return Ok(sonuc); }
            return BadRequest(result.Message);
        }

        //adminin onayını bekleyen postlar(userId ye göre)
        [HttpGet("waitconfirm")] 
        public IActionResult WaitConfirm(string userId)
        {
            var result = _postCategoryService.GetByUserId(userId);
            if (result.Success) { var sonuc = result.Data.Where(w => w.IsActive == false && w.IsDeleted == false); return Ok(sonuc); }
            return BadRequest(result.Message);
        }

       
        [HttpGet("invalidpost")]
        public IActionResult InvalidPost(string userId)
        {
            var result = _postCategoryService.GetByUserId(userId);
            if (result.Success) { var sonuc = result.Data.Where(w => w.IsActive == false && w.IsDeleted == true); return Ok(sonuc); }
            return BadRequest(result.Message);
        }

    }
}