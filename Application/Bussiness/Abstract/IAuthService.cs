using Application.Core.Utilities.Results;
using Application.Core.Utilities.Security.Jwt;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface IAuthService
    {
        //kullanıcının sisteme kayıt olması IDataResult ile data değerini  de döndürebiliriz.
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);

        //Login için gerekli olan email ve password bilgisi userforLoginDto yu parametre olarak verdik.
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

       //Kullanıcı var mı diye kontrol ediyoruz. (Var olan kullanıcıdan bir daha eklememek için)
        IResult UserExists(string email);

        //Token üretmek için
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
