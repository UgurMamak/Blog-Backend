using Application.Core.Utilities.Results;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface ICategoryService
    {
        //Category GetById(int categoryId); //Burada bir data dönecek o zaman IDataResult kulanılır.
        IDataResult<Category> GetById(int categoryId);

        //List<Category> GetList(); Burada da data döneceği için IDataResult kullandık.
        IDataResult<List<Category>> GetList();

        //void Add(Category category); burada data dönmeyecek sadece başarılı mı başarısız mı onu dönecek.(mesajı da istersek döndürebiliriz.)
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
