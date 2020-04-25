using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Core.Extensions
{
    public static class ClaimExtensions
    {
        /*JwtHepler classında Claim özelliklerini belirlerken bazı özellikler claims nesnesinde bulunmamaktadır.
        Extensions yazarak claims nesnesine yeni özelllikler yazarak genişletmiş oluyoruz. exend=genişletmek
        estensions=genişletilmiş class demek.
        */
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            //emaili Email kısmına kaydet demek.
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            //role yapısı list ile geliyo o yüzden foreache sokarak tek tek ekleme işlemi yapılır.
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
