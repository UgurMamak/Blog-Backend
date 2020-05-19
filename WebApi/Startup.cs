using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Bussiness.Abstract;
using Application.Bussiness.Concrete;
using Application.DataAccsess.Abstract;
using Application.Persistence.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.Core.Utilities.Security.Encyption;
using Microsoft.IdentityModel.Tokens;
using Application.Core.Extensions;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Application.Core.Utilities.IOC;
using Application.Core.DependencyResolvers;

//using Microsoft.AspNetCore.Http;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //services.AddScoped<ICategoryService, CategoryManager>();
            // services.AddScoped<ICategoryDal, EfCategoryDal>();          
            //services.AddControllers();

            //Include i�leminde Json'da hata veriyor  o y�zden k�t�phane ekledik.
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //******************CORS setting(Api'ye d��ar�dan request(istek) geldi�inde izin vermek i�in)*************
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));//reactjs url normaled domain verilir.
            });

            //******************TOKEN SETT�NGS*************
            //JWT i�in authentication servisinin sisteme eklemesi autharazation , hem authentication, autharazation middlewarelar� ekledik.
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


            //Core katman�na yazm�� oldu�umuz service collection yap�s�n� ekliyoruz.
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //forntend seviyesi i�in exception middlaware i
            app.ConfigureCustomExceptionMiddleware();

            //CORS i�in middleware verdik.
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader()); //yay�na ��kt���m�zda kendi domainimizi verece�iz.

             app.UseHttpsRedirection();

            app.UseRouting();


            
           

            //sonradan ekledim.
            app.UseAuthentication();//anahtar Do�rulamad�r

            app.UseAuthorization();//ne yapabilir.  YETK�dir.

            app.UseStaticFiles(); // For the wwwroot folder (url ile static dosyalara eri�mek i�in eklemnmesi gereken middleware)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
