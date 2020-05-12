using Application.Bussiness.BusinessAspects.Autofac;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Extensions
{
    public class ExceptionMiddleware
    {

        private RequestDelegate _next; //middleware yazmak için request delegasyonuna ihtiyaç vardır.

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        //oluşturulan operasyon hata verirse 
        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            /*
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
           if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
            }
        

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
            */


            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error Burada";

            if (e is EntryPointNotFoundException) httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

            else if (e is UnauthorizedAccessException) httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            
            if (e.GetType() == typeof(ValidationException))
            { message = e.Message; }


            if (e.GetType() == typeof(SecuredException))
            { message = e.Message; }


            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());




        }
    }
}
