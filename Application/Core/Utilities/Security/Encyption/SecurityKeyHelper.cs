using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Security.Encyption
{
    public class SecurityKeyHelper
    {
        /*
         Bizim için Securitykeyi yaratarak şifreleyecek.
         */
         //parametre olarak jwthelper'dan gelen securitykey alır.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //şifrelenmiş securityKey döndürür.
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
