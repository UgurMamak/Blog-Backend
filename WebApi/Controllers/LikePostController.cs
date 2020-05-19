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
            
            if(gonder=="2")return Ok();


            if(gonder=="0")               
            {
               var result= _likePostService.Add(likePostCreateDto);
                var updateNumber = _likePostService.GetNumberStatus(likePostCreateDto.PostId);
                if (result.Success)
                {
                    return Ok(updateNumber.Data);
                }
            }
            
            if(gonder=="1")
            {
                var delete = _likePostService.Delete(likePostCreateDto);
                if(delete.Success)
                {
                    var result = _likePostService.Add(likePostCreateDto);
                    var updateNumber = _likePostService.GetNumberStatus(likePostCreateDto.PostId);
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
            { return Ok(result.Data);}
            return BadRequest(result.Message);
        }

        [HttpGet("getnumberstatus")]//+++
        public IActionResult GetNumberStatucDto(string postId)
        {
            var result = _likePostService.GetNumberStatus(postId);
            if (result.Success)
            { return Ok(result.Data); }
            return BadRequest(result.Message);
        }





    }
}