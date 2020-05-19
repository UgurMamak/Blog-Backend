using Application.Bussiness.Abstract;
using Application.Bussiness.Concrete;
using Application.Core.Utilities.Interceptors;
using Application.Core.Utilities.Security.Jwt;
using Application.DataAccsess.Abstract;
using Application.DataAccsess.Concrete.EntityFramework;
using Application.Persistence.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
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
            builder.RegisterType<CategoryService>().As<ICategoryService>();  //Birisi ctor'unda ICategoryService isterse bu kod ona CategoryManager'ı verecek.
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();


            builder.RegisterType<PostService>().As<IPostService>();  //Birisi ctor'unda ICategoryService isterse bu kod ona CategoryManager'ı verecek.
            builder.RegisterType<EfPostDal>().As<IPostDal>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<PostCategoryService>().As<IPostCategoryService>();
            builder.RegisterType<EfPostCategoryDal>().As<IPostCategoryDal>();


            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();


            builder.RegisterType<AuthService>().As<IAuthService>();
            //Jwt helper'a gidip bağımlılıklarına bakıyoruz.
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            

            //Bu servislerin nesneler için ınterceptor çalıştımak gerekiyor
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();//assembly e ulaşır

           // assemblydeki tüm tipleri kayırt et 
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
                

        }
        
    }
}
