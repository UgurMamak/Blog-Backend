using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        //Erişim anahtarı olacak.
        public string Token { get; set; }//Token anahtarının kendisini tutacak
        public DateTime Expiration { get; set; }//Tokennın ne zamana kadar geçerli olduğu bilgisini tutacak.

        public string UserId { get; set; }
        
        public List<OperationClaim> Role { get; set; }
      

        /*Refresh token eklenebilir. (Kullanıcının Token kullanma süresi bitti diyelim yeniden login yapmasını yani yeni token oluşturmak yerine
        mevcut tokenı yeniden kullanabilmesini sağlayabiliriz.)
        Burada yapılır.
        */
    }
}
