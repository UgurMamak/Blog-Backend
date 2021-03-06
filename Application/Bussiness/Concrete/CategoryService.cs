﻿using Application.Bussiness.Abstract;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Persistence.EntityFramework;
using Application.Core.Utilities.Results;
using Application.Bussiness.Constants;
using Application.Bussiness.ValidationRules.FluentValidation;
using FluentValidation;
using Application.Core.CrossCuttingConcers.Validation;
using Application.Core.Aspects.Autofac;
using Application.Bussiness.BusinessAspects.Autofac;
using Application.Core.Aspects.Autofac.Validation;
using Application.Persistence.Dtos;

namespace Application.Bussiness.Concrete
{
    public class CategoryService : ICategoryService
    {
        //NOTLAR
        //IcategoryService de yazdığımız metotlar buraya implemente edilir.
        //ICategoryDal'da ki metotlar burada kullanılır. 
        //Validation işlemleri de burada kodlanacak.

        //Dependency injection yapabilmek iiçin field oluşturduk.
        private ICategoryDal _categoryDal;

        //ICategoryDal referans tiptir.  bunu implement eden kimse onu kullanabiliriz(örneği EfCategoryDal gibi)
        //Başka bir ORM geldiğinde ICategoryDalı implement ederse onuda verebiliriz.
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public IDataResult<Category> GetById(string categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(s => s.Id == categoryId));
        }

        //Role verme işlemi
        //[SecuredOperation("Operator")] //Operator User //[SecuredOperation("Product.List,Admin")]
        //[SecuredOperation("SystemAdmin")] //Operator User //[SecuredOperation("Product.List,Admin")]
        public IDataResult<List<Category>> GetList()
        {        
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

      //  [ValidationAspect(typeof(CategoryValidator),Priority =1)]
        public IResult Add(Category category)
        {
            //Bu alanı normalde böyle kullanabiliriz fakat her metot için böyle yazılmaktansa bu kod bloğu merkezileştirilerek daha pratik kullanılabilir.
            // Merkezileştirmek için Core katmanında validationTool classı oluşturdum.
            /*
            CategoryValidator categoryValidation = new CategoryValidator();
            var result = categoryValidation.Validate(category);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            */

            //yukarıda yazılanlar aşağıdaki şekilde refactor edilerek daha düzeni hale getirildi.
           //ValidationTool.Validate(new CategoryValidator(),category); attirubute yazmak yerine bu nuda kullanabiliriz.

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

        public IResult CategoryExists(string categoryName)
        {
            //yazılan kategori var mı yok mu kontrol edilir.
            var exist = _categoryDal.Get(c=>c.CategoryName.ToLower()==categoryName.ToLower());
            
            if (exist!=null)
            {
                return new ErrorResult(Messages.CategoryAlreadyExists);//eğer kategori varsa ErrorDataResult döndüreceğiz.
            }
            return new SuccessResult(); 
        }
    }
}
