using Application.Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.DependencyResolvers
{
   public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            //services.AddSingleton<ICacheManager, MemoryCacheManager>();
            //Tekil oluşmasını istediğimiz için AddSingleton kullandım.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<Stopwatch>();
        }
    }
}
