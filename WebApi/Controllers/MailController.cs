using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Application.Persistence.Dtos.MailDtos;
using Application.Bussiness.Concrete;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
     

        //iletişim ekranı için yazıldı.
        [HttpPost("mailsend")]
        public async Task<IActionResult> SendMail([FromForm] MailCreateDto mailCreateDto)
        {
            try
            {
                string body ="<b>Ad Soyad:</b>"+mailCreateDto.Name +"<br/>"+"<b>Mail adresim:</b>" + mailCreateDto.Mail + "<br/>" + mailCreateDto.Content;
                mailCreateDto.Mail = "ugurmamak98@gmail.com";
                mailCreateDto.Name = "uğur mamak";
                SendMail send = new SendMail();
                send.Mail(mailCreateDto,body);
            }
            catch (Exception ex)
            {
                return BadRequest("Mesaj iletirken hata oluştu.");
                throw ex;
            }
            return Ok("Mesajınız iletildi");
        }
    }
}