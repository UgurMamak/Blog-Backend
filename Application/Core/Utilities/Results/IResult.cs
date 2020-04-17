using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Results
{
    public interface IResult
    {
        //Yapılan işlemin başarılı olup olamdığına ve mesaj döndürmek için oluşturuldu.
        bool Success { get; }   //yapılan işlem başarılı mı görmek için

        string Message { get; } // yapılan işlemin mesajı için 
    }
}
