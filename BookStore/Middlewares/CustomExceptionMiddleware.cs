using BookStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Middlewares
{
    public class CustomExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        public readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next , ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {

            var watch = Stopwatch.StartNew();//request-response arasında ne kadar süre geçtiğini izle

            try
            {

              
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);
                //Bir sonraki middleware çağırdık
                await _next(context);//Request bittikten sonra buraya düştü
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded "
                    + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms ";

                ;

            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleExcepiton(context , ex , watch) ;
            }

          



        }

        private Task HandleExcepiton(HttpContext context, Exception ex, Stopwatch watch)
        {
            //Error mesajını eziyoruz.Kendi error mesajımızı ayarlıyoruz

            context.Response.ContentType = "application/json";
            //200 yerine hata kodu dönsün diye ayarlama yapıyorum.
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error message " 
                + ex.Message + " in " + watch.Elapsed.TotalMilliseconds;
            _loggerService.Write(message);


            //Error mesajını json olarak dönmek için ayarlama yapıyorum
            var result = JsonConvert.SerializeObject(new { error = ex.Message},Formatting.None);
            return context.Response.WriteAsync(result);

        }
    }

    static public class CustomExceptionMiddlewareExtension
    {

        static public IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder) 
        {

            return builder.UseMiddleware<CustomExceptionMiddleware>();
        
        }
    }



}
