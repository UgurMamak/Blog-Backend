using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Results
{
    public interface IDataResult<out T> : IResult
    {
        //Yapılan işlem için success ve mesaj dışında data'nın dönmesi gereken durumlarda DataResult kullanıcalack. Bu yüzden DataResult oluşturuldu.
        //IReseulttaki message ve success değişkenleri buraya implement edilmiş demek.
        //interface olduğu için implement etmeye gerek yoktur.
        T Data { get; }//döndürmek istediğimiz data
    }
}
