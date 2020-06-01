using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Persistence.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static System.Net.Mime.MediaTypeNames;

//MAil için
using System.Net;
using System.Net.Mail;
using Microsoft.IdentityModel.Protocols;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        // IHostingEnvironment
        public DenemeController(IWebHostEnvironment environment)
        {

            _environment = environment;
        }


        [HttpPost("mail")]
      
       // public async Task<IActionResult>MailGonder([FromForm] IFormFile dosya )
        public async Task<IActionResult>MailGonder(IFormFile dosya)
        {
            try
            {
                string file = "comment.txt";
                MailMessage msg = new MailMessage();
                msg.Subject = "Mesaj başlığı";
                msg.From = new MailAddress("ugurmamakk@gmail.com", "uğur mamak");//gönderen
                msg.To.Add(new MailAddress("ugurmamak98@gmail.com", "uğur mamak"));//alan
                msg.Body = "Mesaj içeriği buraya" + msg.From.Address;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                // Host ve Port Gereklidir!          
                /*
                Attachment a = new Attachment(dosya.FileName, dosya.ContentType);
                //Attachment a = new Attachment(dosya.ContentType,dosya.FileName);
                msg.Attachments.Add(a);
                */
                Attachment data = new Attachment(dosya.FileName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(dosya.FileName);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(dosya.FileName);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(dosya.FileName);
                // Add the file attachment to this email message.
                msg.Attachments.Add(data);


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
                NetworkCredential AccountInfo = new NetworkCredential("ugurmamak98@gmail.com", "134ugur2163");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(msg);
                data.Dispose();
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw ex;
            }          
            return Ok();
        }






        [HttpPost("mail2")]
        public async Task<IActionResult> MailGonder2([FromForm] MesajIcerik mail)
        {
            try
            {
              
                MailMessage msg = new MailMessage();
                msg.Subject = "Mesaj başlığı";
                //msg.From = new MailAddress("ugurmamak98@gmail.com", "uğur mamak");//gönderen //buraya reacttan gelen adres yazılacak.
                msg.From = new MailAddress(mail.MailAdres, mail.AdSoyad);//gönderen //buraya reacttan gelen adres yazılacak.
                //msg.To.Add(new MailAddress("ugurmamakk@gmail.com", "uğur mamak"));//mesajın gittiği adres
                msg.To.Add(new MailAddress("ugurmamak98@gmail.com", "uğur mamak"));//mesajın gittiği adres
                msg.Body = mail.Icerik + msg.From.Address;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
               

                Attachment data = new Attachment(mail.dosya.OpenReadStream(),mail.dosya.FileName);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(mail.dosya.FileName);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(mail.dosya.FileName);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(mail.dosya.FileName);
                // Add the file attachment to this email message.
                msg.Attachments.Add(data);


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
                NetworkCredential AccountInfo = new NetworkCredential("ugurmamak98@gmail.com", "134ugur2163");//alan kişi
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(msg);
                data.Dispose();
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw ex;
            }


            return Ok();
        }





        [HttpPost("uploadfile3")]
        //  [Produces("application/json")]
        public async Task<IActionResult> UploadFile3([FromForm] IFormFile image)
        {
            string Id = Guid.NewGuid().ToString();

            if (image == null)
            {
                return BadRequest("null");

            }
            Random a = new Random();
            int b = a.Next(1, 100);

            var resimler = Path.Combine(_environment.WebRootPath, "img");
            var imageName = $"{Id}.jpg";

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                {
                   
                    await image.CopyToAsync(fileStream);
                }
            }
            //apiFile.ResimYolu = apiFile.ResimDosyasi.FileName;

            //return BadRequest();
            return Ok("başarılı");
        }

        [HttpGet("getimg")]
        public async Task<IActionResult> GetImage()
        {
            return Ok("https://localhost:5001/img/1a460431-216a-49ff-9733-3cf3ebd0dadb.jpg");
        }


        [HttpPost("uploadfile4")]
        //  [Produces("application/json")]
        public async Task<IActionResult> UploadFile4([FromForm] IFormFile image, [FromForm] Bilgiler bilgiler)
        {
            string Id = Guid.NewGuid().ToString();

            if (image == null)
            {
                return BadRequest("null");

            }
            Random a = new Random();
            int b = a.Next(1, 100);

            var resimler = Path.Combine(_environment.WebRootPath, "img");
            var imageName = $"{Id}.jpg";

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
            //apiFile.ResimYolu = apiFile.ResimDosyasi.FileName;

            //return BadRequest();
            return Ok("başarılı");
        }


        [HttpPost("deneme")]
        //  [Produces("application/json")]
        public async Task<IActionResult> Deneme(PostCategoryCreateDto postCategoryCreateDto)
        {

            return Ok(postCategoryCreateDto);
        }

        [HttpPost("deneme2")]
        //  [Produces("application/json")]
        public async Task<IActionResult> Deneme2([FromForm] Bilgiler bilgiler)
        //public IActionResult Deneme2(Bilgiler bilgiler)//bu şekilde olunca çalııyor
        {
            string cat = "";

            string[] parcalar = bilgiler.category.Split("*");
            int sayac = 0;
            foreach (var item in parcalar)
            {
               
                string eleman = item;
                if(item!="")
                sayac++;
            }
            int sonuc = sayac;
            return Ok(bilgiler);
        }
    }


    public class MesajIcerik
    {
        public string MailAdres { get; set; }
        public string AdSoyad { get; set; }
        public IFormFile dosya { get; set; }
        public string Icerik { get; set; }
    }





    public class FIleUploadAPI2
    {
        public IFormFile files { get; set; }
    }

    public class Bilgiler
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        //public List<Category2> category { get; set; }

        public  string category { get; set; }
        public IFormFile image { get; set; }
    }

    public class Bilgiler2
    {
        public IFormFile image { get; set; }
    }
    public class Category2
    {
        public string categoryId { get; set; }
    }

}