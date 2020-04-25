using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Persistence.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
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


        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);//Kullanıcının girdiği email bilgisinin Db'de olup olamdığını kontrol ettik.
            //userExists'in geridönüş değeri SuccessResult'tır. Buradan işlemin başarılı olup olmadığını kontrol edebiliriz.
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);//registerResult'ın döndüğü Data(User) bilgisini token üretmek için parametre olarak verdim.
            if (result.Success)
            {
                return Ok(result.Data);//işlemler başarılıysa token değeri döndürülür.
            }

            return BadRequest(result.Message);
        }

    }
}