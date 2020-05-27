using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos.LikePostDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikePostController : ControllerBase
    {
        private ILikePostService _likePostService;
        public LikePostController(ILikePostService likePostService)
        {
            _likePostService = likePostService;
        }
        [HttpPost("add")]//++++
        public IActionResult Add(LikePostCreateDto likePostCreateDto)
        {
            var gonder = _likePostService.LikePostExists(likePostCreateDto);
           
            /*var updateNumber2 = _likePostService.GetNumberStatus(likePostCreateDto.PostId);
            if (gonder=="2")return Ok(updateNumber2.Data);*/

            if(gonder=="2")
            {
                var delete = _likePostService.Delete(likePostCreateDto);
                if(delete.Success)
                {
                    var updateNumber = _likePostService.GetNumberStatus(likePostCreateDto.PostId);
                    if (likePostCreateDto.LikeStatus == true) updateNumber.Data.Message = "Beğeni kaldırıldı.";
                    else updateNumber.Data.Message = "Beğenmeme geri kaldırıldı.";
                    return Ok(updateNumber.Data);
                }
            } 

            //Hiç kayıt yok yeni kayıt ekle
            if(gonder=="0")               
            {
               var result= _likePostService.Add(likePostCreateDto);
                var updateNumber = _likePostService.GetNumberStatus(likePostCreateDto.PostId);
                if (result.Success)
                {
                    if (likePostCreateDto.LikeStatus == true) updateNumber.Data.Message = "Bu postu beğendiniz";
                    else updateNumber.Data.Message = "Bu postu beğenmediniz";
                    return Ok(updateNumber.Data);
                }
            }
            
            //kayıt var ama güncelleme işlemi yapılacak.
            if(gonder=="1")
            {
                var delete = _likePostService.Delete(likePostCreateDto);
                if(delete.Success)
                {
                    var result = _likePostService.Add(likePostCreateDto);
                    var updateNumber = _likePostService.GetNumberStatus(likePostCreateDto.PostId);

                    if (likePostCreateDto.LikeStatus == true) updateNumber.Data.Message = "Bu postu beğendiniz";
                    else updateNumber.Data.Message = "Bu postu beğenmediniz.";

                    if (result.Success)
                    {
                        return Ok(updateNumber.Data);
                    }
                }
            }         
            /*
            var result= _likePostService.Add(likePostCreateDto);
            var updateNumber = _likePostService.GetNumberStatus(likePostCreateDto.PostId);
            if(result.Success)
            {
                return Ok(updateNumber.Data);
            }
            return BadRequest(result.Message);
            */
            return BadRequest();
        }

        [HttpGet("getall")]//+++
        public IActionResult GetList()
        {                    
            var result = _likePostService.GetList();
            if (result.Success)
            {                 
                return Ok(result.Data);}
            return BadRequest(result.Message);
        }

        [HttpGet("getnumberstatus")]//+++
        public IActionResult GetNumberStatucDto(string postId)
        {
            var result = _likePostService.GetNumberStatus(postId);
            result.Data.Message = "";
            if (result.Success)
            { return Ok(result.Data); }
            return BadRequest(result.Message);
        }





    }
}