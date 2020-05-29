using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Bussiness.Concrete;
using Application.Core.Aspects.Autofac.Transaction;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.MailDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private readonly IWebHostEnvironment _environment;
        public AuthController(IAuthService authService, IWebHostEnvironment environment)
        {
            _authService = authService;
            _environment = environment;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            //Bu kodlar geliştirilebilir Hata Yönetimi olarak eksiklikleri var
            var userToLogin = _authService.Login(userForLoginDto); //_authService'e gidip login operasyonunu çalıştırır.

            // service'de return olarak succesDataResult vermiştik. o değerden succces değerini, Message değerlerini ve Data değerini çekebiliriz.
            if (!userToLogin.Success)//işlme sonucu başarılı değilse badrequest döndürüyoruz.
            {

                return BadRequest(userToLogin.Message);
            }
            //eğer if'e girmediyse login başarılıdır. Bunun için access token üretimi gerçekleştireceğiz.

            var result = _authService.CreateAccessToken(userToLogin.Data);//gelen kullanıcı bilgisini token üretimi için gönderiyoruz.

            if (result.Success)
            {
                return Ok(result.Data);//işlem başarılıysa üretilen token değeri döndürülür.
            }

            return BadRequest(result.Message);//üretmede hata varsa message yazdırılır.

        }


        [HttpPost("register")]//kullanıcı bilgileri ve resim bilgisi gelmektedir.
                              // public async Task<IActionResult> Register([FromForm] IFormFile image, [FromForm] UserForRegisterDto userForRegisterDto)
        public async Task<IActionResult> Register([FromForm] UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);//Kullanıcının girdiği email bilgisinin Db'de olup olamdığını kontrol ettik.
            //userExists'in geridönüş değeri SuccessResult'tır. Buradan işlemin başarılı olup olmadığını kontrol edebiliriz.
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            string Id = Guid.NewGuid().ToString();//resimlere guid Id şeklinde isim ataması yaptım.
            var resimler = Path.Combine(_environment.WebRootPath, "userImage");//dizin bilgisi
            string imageName = $"{Id}.jpg";//Db ye kaydedilecek olan resimlerin ismi

            if (userForRegisterDto.Image == null)
            {
                //return BadRequest("Resim Bilgisi Boş");
                imageName = "profileImage.jpg";
            }

            string password="";
            if(userForRegisterDto.processType== "SystemAdmin")
            {
                RandomPassword pass = new RandomPassword();
                 password = pass.password();
                userForRegisterDto.Password = password;
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password, imageName);
            var result = _authService.CreateAccessToken(registerResult.Data);//registerResult'ın döndüğü Data(User) bilgisini token üretmek için parametre olarak verdim.
            if (userForRegisterDto.Image != null)
            {
                if (userForRegisterDto.Image.Length > 0)
                {

                    using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                    {
                        await userForRegisterDto.Image.CopyToAsync(fileStream);
                    }
                }
            }

            if (registerResult.Success)
            {
                if(password!="")
                {
                    string body = "Merhaba" + userForRegisterDto.FirstName + " " + userForRegisterDto.LastName + "<br/>" + " Başvurunuz dikkate alınarak size hesap oluşturulmuştur." +
                    "  Sisteme giriş yapmak için <br/> bize iletmiş olduğunuz mail adresini:" + "<b>" + userForRegisterDto.Email + "</b>" + "<br/> ve şifre olarak" + "<b>" + password + "<b/><br/>" + "kullanabilirsiniz." +
                    "<br/>Sisteme giriş yaptıktan sonra profil resminizi ve şifrenizi güncelleyebilirsiniz.";

                    MailCreateDto gonder = new MailCreateDto {
                        Content = body,
                        Mail=userForRegisterDto.Email,
                        Name=userForRegisterDto.FirstName+" "+userForRegisterDto.LastName,
                        Subject="Adminlik ve Opetatör başvurusu"                     
                    };

                    SendMail send = new SendMail();
                    send.Mail(gonder, body);
                }
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}