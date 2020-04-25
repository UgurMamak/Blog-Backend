using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Security.Jwt
{
   public interface ITokenHelper
    {

        /*İnterface oluşturma sebebimiz şuan jwt token kullanıyoruz ama başka bir zamanda başka bir token tekniği gelebilir ve biz yeni gelen tekniği
         * kullanabiliriz. Bu sefer Classı tekrar
         * Bu şekilde yaparak Solid prensibine de uymuş olacapız çünkü mevcut kod değişmez ama geliştirilebilir olmalıdır.
         */

        //User nesnesine ihtiyaç var user bilgisi dönecek ona göre token üretecek. Aynı zamanda kullanıcının rollerinin de gelmesini istioruz.
        //yani kullanıcı bilgisi ve rolleri vermiş olduk.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
