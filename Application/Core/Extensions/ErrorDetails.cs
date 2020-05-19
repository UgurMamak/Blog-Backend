using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Application.Core.Extensions
{
    public class ErrorDetails
    {

        public string Message { get; set; }//kullanıcıya gidecek mesaj
        public int StatusCode { get; set; } //gönderilecek hata kodu

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);//yukarıdaki nesneyi serileştirir.
        }
    }
}
