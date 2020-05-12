using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Aspects.Autofac.Transaction;
using Application.Core.Utilities.Results;
using Application.Core.Utilities.Security.Hashing;
using Application.Core.Utilities.Security.Jwt;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Concrete
{
    public class AuthService : IAuthService
    {
        IUserService _userService;//Kullanıcıyı kontrol etmek için kullanacağız. veri tabanında var mı? diye
        ITokenHelper _tokenHelper;
        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);//kontrol etmek için
            if (userToCheck == null)//mail Dbde yoksa
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            //Kullanıcının bize açık olarak gönderdiği bir password var biz bunu hashleyip Dbde ki hash'lı password ile karşılaştırmamız gerekiyor.
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            //return new SuccessDataResult<User>(userToCheck);/Bu şekilde de olabilir ama mesaj yazdırmak istiyorsak bu şekilde yapabiliriz.
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
            //userToCheck ifadesi User bilgisidir.
        }

        //Kullanıcı var mı diye kontrol işlemi yapacağız. Register işlemi yaparken girilen email bilgisinin Db'de olup olmadığını kontrol etmek için oluşturuldu.
        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);//eğer kullanıcı varsa ErrorDataResult döndüreceğiz.
            }
            return new SuccessResult();
        }


        /*
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            //metota verilen string password olamasa da olur. Çünkü password değeri userForRegisterDto içinde var.
            //string password kullanıcının texte girdiği haslenmemiş parola

            byte[] passwordHash, passwordSalt; //işlem bitince bunlar oluşacak

            //bu çalışınca hash ve salt değerleri dönecek. bu operasyon dönünce yukarıda tanımlanan değerlerde değişecek.
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
        */

        //Token yaratacak
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            /* Kullanıcı kayıt olduktan veya login olduktan token yaratılıcak. ve kullanıcı işlemlerini bu token vasıtasıyka gerçekleştirecek.
             * Aşağıdaki kodlar başarılı olma durumunda olabilecek işlemler başarısız işlem olma durumunda da burada eklemeler yapmalıyız
             */

            var claims = _userService.GetClaims(user);//user rollerini döndürecek (Kullanıcının sahip olduğu rolleri dönecek.)
            var accessToken = _tokenHelper.CreateToken(user, claims);//user bilgisi ve roll bilgisini token oluşturacak operasyona parametre olarak veriyoruz.
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


        //******************************2
        /*
        public IDataResult<User> AddUserOperationClaim(UserForRegisterDto userForRegisterDto,string userId)
        {
             _userService.AddUserRole(userForRegisterDto,userId);
             return new SuccessDataResult<User>();
        }*/


        [TransactionScopeAspect]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password,string imgName)
        {

            //metota verilen string password olamasa da olur. Çünkü password değeri userForRegisterDto içinde var.
            //string password kullanıcının texte girdiği haslenmemiş parola

            byte[] passwordHash, passwordSalt; //işlem bitince bunlar oluşacak

            //bu çalışınca hash ve salt değerleri dönecek. bu operasyon dönünce yukarıda tanımlanan değerlerde değişecek.
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                ImgName=imgName
            };
           _userService.Add(user);
            
            var registerSave= new SuccessDataResult<User>(user, Messages.UserRegistered);
            _userService.AddUserRole(userForRegisterDto, registerSave.Data.Id);//kayıt işleminden sonra role tablosuna kaydetme işlemine geçer.
            //return new SuccessResult(registerSave.Message);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

    }
}
