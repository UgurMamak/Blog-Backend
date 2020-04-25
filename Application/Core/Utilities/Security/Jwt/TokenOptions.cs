using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Security.Jwt
{
   public class TokenOptions
    {
        //Jwt token stadart ayarları için tanımlamaları yaptık.
       
        public string Audience { get; set; }//bizim bu tokenımızın  kullanıcı kitlesi
        public string Issuer { get; set; }// imzalayan
        public int AccessTokenExpiration { get; set; }//erişim dakika cinsinden yazılır.
        public string SecurityKey { get; set; }//
    }
}
