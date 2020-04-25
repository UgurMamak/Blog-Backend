using Application.Core.Utilities.Security.Encyption;
using Application.Persistence.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Core.Extensions;
using System.Linq;

namespace Application.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        //JWT token üretimi yapacak olan yer

        //Configurasyon dosyası okumak için gerekli alt yapı kurulur.
        public IConfiguration Configuration { get; }//sadece readonly

        private TokenOptions _tokenOptions;//Configurasyon dosyasında(appsetting.json dosyası) TokenOptions diye alanımız olacak. Ve O Token options ayarları burdaki TokenOptions' nesnesine aktaracak.

        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            //appsetting.json daki bilgiyi token option bilgilerini okuyacak.(configuration işlemi ile)
            Configuration = configuration;

            //Configurasyon dosyasında TokenOptions Kısımını oku demek. Ve onu TokenOptions nesnesine bind et.
            //Bu şekilde _tokenOptions nesnesi olmuş oluyo.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Bu yapı standart olduğu için ve biz bunu projenin her yerinde kullanabiliriz bunun için SecurityKeyHelper adında class oluşturarak ordan çağıracağız.
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Securitykey helper classındki metota securitykey göndererek şifrelenmiş seckey alacak.

            //yukarıda oluşan securityKey anahtarını parametre olarak verdik.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);


            /*_tokenOptions'daki bilgileri, Kullanıcı bilgilerini, signingCredentials bilgilerini ve  kullanıcı rollerini kullanarak token oluşturacağız.
              Jwt token oluşturmak için operasyonu çağırdık ve parametreleri gönderdik.*/
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);


            //elimizde olan tokenı elimizdeki bilgilere göre handler vasıtasıyla yazıyo olmamız gerekiyor.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();            
            var token = jwtSecurityTokenHandler.WriteToken(jwt);


            //AccessToken döndürmemiz gerekiyor. (Jwt/AccessToken classında bulunan property değeri)
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        //tokenoptionslar, hangi kullanıcı, signing ayarları, ve kullanıcınns ahip olduğu roller parametre olarak verdik.
        //Bu metot json web token oluşturacak.
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,//dk cinsinde olduğu için yukarıda convert işlemini yaptık.
                notBefore: DateTime.Now,//token expression bilgisi şuandan önceyse geçerli değil demek
                claims: SetClaims(user, operationClaims), //Kullanıcının sahip olduğu role bilgileri
                signingCredentials: signingCredentials
            );
            return jwt;
        }



        //Claim nesnesine özelliklerini set ettik.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            /* claims nesnesinde AddEmail,AddName gibi özellikler yok bunun için ilk önce bu özellikleri claims nesnesine eklememiz gerekiyor. 
             * Bunu sağlamak için claim nesnesi extend edeceğiz. extensions(uzantılar)
             */
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }



    }
}
