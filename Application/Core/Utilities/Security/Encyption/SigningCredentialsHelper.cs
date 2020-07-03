using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Security.Encyption
{
    public class SigningCredentialsHelper
    {
        /*
         * securitykey ve algoritmamızı belirlediğimiz yer olacak.
         */
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
 