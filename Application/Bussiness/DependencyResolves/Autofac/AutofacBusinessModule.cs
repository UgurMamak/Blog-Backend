using Application.Bussiness.Abstract;
using Application.Bussiness.Concrete;
using Application.DataAccsess.Abstract;
using Application.Persistence.EntityFramework;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.DependencyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        // Şu interface'in karşılığı bu  soyutun karşılığı bu dur dediğimiz dosyalardır.

        //Load konfigürasyonları yağtığımız yerdir.
        protected override void Load(ContainerBuilder builder)
        {
            //categoryManager'ı ICateoryService olarak kaydet
            builder.RegisterType<CategoryManager>().As<ICategoryService>();  //Birisi ctor'unda ICategoryService isterse bu kod ona CategoryManager'ı verecek.
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        }
        
    }
}
