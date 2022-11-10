using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ConsoleLoggerMiddleware>(); // We are registering the custom middleware to the Service
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*Using AppBuilder class we can have 3 methods to configure middleware
            -> app.Run() : This is used at the end when there's no more middleware component(terminal delegates).
            -> app.Use() : This s used to connect one ore more middleware components.
            ->app.Map() : This is used to create branching of middleware. */

        
           /* app.Use(async(Context, next) => 
            {
                Console.WriteLine("Before Request"); 
                await next(); // Next here is the next middleware which is app.Run(). Once that's done executing this middleware would resume.
                Console.WriteLine("After Request");

            }); This is inline middleware. We have used custom middleware and placed it in different file(ConsoleLoggerMiddleware)*/

            app.UseMiddleware<ConsoleLoggerMiddleware>(); // using the custom middleware instead of inline

            //Map method is used to branch the middleware pipelines into different pipelines
            app.Map("/map", MapHandler); // the '/map' is the request url path.

            //There are 2 more extensions for Map method: app.MapWhen and app.UseWhen
            //app.MapWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);

            //app.USe when is used when u dont want to break the pipeline.
            app.UseWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);


            //This is a request delegate / a asp.net middleware
            app.Run(async context =>
            {
                Console.WriteLine("Hello World");
                await context.Response.WriteAsync("Hello World");
            }); 

            
            
        }

        private static void MapHandler(IApplicationBuilder app)
        {
            app.Run(async context =>{
                Console.WriteLine("Hello from Map method");
                await context.Response.WriteAsync("Hello from map");
            });
        }

         private static void HandleRequestWithQuery(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>{
                Console.WriteLine("Contains Query");
                await context.Response.WriteAsync("Hello from mapQuery");
                await next();
            });
        }
    }
}