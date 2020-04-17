using Application.Bussiness.Abstract;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Persistence.EntityFramework;
using Application.Core.Utilities.Results;
using Application.Bussiness.Constants;

namespace Application.Bussiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //NOTLAR
        //IcategoryService de yazdığımız metotlar buraya implemente edilir.
        //ICategoryDal'da ki metotlar burada kullanılır. 
        //Validation işlemleri de burada kodlanacak.

        //Dependency injection yapabilmek iiçin field oluşturduk.
        private ICategoryDal _categoryDal;

        //ICategoryDal referans tiptir.  bunu implement eden kimse onu kullanabiliriz(örneği EfCategoryDal gibi)
        //Başka bir ORM geldiğinde ICategoryDalı implement ederse onuda verebiliriz.
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(s => s.Id == categoryId));
        }


        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IResult Add(Category category)
        {          
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
