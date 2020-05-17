using Application.Bussiness.Constants;
using Application.Core.Extensions;
using Application.Core.Utilities.Interceptors;
using Application.Core.Utilities.IOC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.Results;

namespace Application.Bussiness.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;//operasyonun talep ettiği yetkiler
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');      
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //kullanıcının talep ettiği yetkileri getirecek.
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles) 
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new SecuredException(Messages.AuthorizationDenied);            
        }
    }



    public class SecuredException : Exception
    {
        private IList<ValidationFailure> errors;

        public SecuredException(string message) : base(message)
        {
           
        }
    }
 

}
