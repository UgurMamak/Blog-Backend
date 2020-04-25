using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Entity
{
   public class OperationClaim
   {
        //Role bazlı kimlik doğrulama
        //Yetki isimlerini tutacak (ROLE)
        //Admin,User(role tipleri)
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
