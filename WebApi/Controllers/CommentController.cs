using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentservice;
        public CommentController(ICommentService commentService)
        {
            _commentservice = commentService;
        }


        [HttpGet("getlist")]
        public IActionResult Getlist()
        {
            var result = _commentservice.GetList();
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]//+++
        public IActionResult Add(CommentCreateDto commentCreateDto)
        {
            var result = _commentservice.Add(commentCreateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbypostId")]//+++
        public IActionResult GetByPostId(string postId)//postId'ye göre listeleme işlemi
        {
            var result = _commentservice.GetByPostId(postId);
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]//+++
        public IActionResult Delete(Comment comment)
        {
            var result = _commentservice.Delete(comment);
            if (result.Success) { return Ok(result.Message); }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(CommentUpdateDto comment)
        {
            var result = _commentservice.Update(comment);
            if (result.Success){return Ok(result.Message);}
            return BadRequest(result.Message);
        }


    }
}