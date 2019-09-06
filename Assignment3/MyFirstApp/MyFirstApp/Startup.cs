using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstApp.CustomMiddleware;
using System.Threading.Tasks;

namespace MyFirstApp
{
    public class Startup
    {
        #region "Private variables"
        private readonly IConfiguration _configuration;
        #endregion

        #region "Startup"
        public Startup(IConfiguration configuration) => _configuration = configuration;
        #endregion

        #region "ConfigureServices"
        // This method gets called by the runtime. Use this method to add services to the container.
        //Register custom middleware.
        public void ConfigureServices(IServiceCollection services) => services.AddSingleton(typeof(MyMiddleware));
        #endregion

        #region "Configure"
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseMyMiddleware();

            //app.UseWelcomePage();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //Use delegate
            app.Use(async (Context, next) =>
            {
                await Context.Response.WriteAsync(_configuration["Mykey"]);
                await Context.Response.WriteAsync("\nA (before)\n");
                await next();
                await Context.Response.WriteAsync("A (after)\n");
            });

            //UseWhen delegate
            app.UseWhen(
                Context => Context.Request.Path.StartsWithSegments(new PathString("/Usewhen")),
                a => a.Use(async (Context, next) =>
                {
                    await Context.Response.WriteAsync("B (before)\n");
                    await next();
                    await Context.Response.WriteAsync("B (after)\n");
                }));

            //Run delegate
            app.Run(async Context =>
                {
                    await Context.Response.WriteAsync("c\n");
                    await Context.Response.WriteAsync("Hello World\n");
                });

            //MapWhen delegate
            app.MapWhen(Context => Context.Request.Query.ContainsKey("branch"), MyFirstMapMethod);

            //Map delegate using different paths
            app.Map("/map", MyFirstMapMethod);
            
            app.Map("/map1", MySecondtMapMethod);

            //Nested Map
            app.Map("/map2",
                FirstMiddleware => FirstMiddleware.Map("/map2a",
                SecondMiddleware => SecondMiddleware.Run(async (context) =>
                await context.Response.WriteAsync("Hello from Nested Middleware\n"))));

            //Run delegate using public method.
            app.Run(MyFirstMiddlewareAsync);
        }
        #endregion

        #region "MyFirstMiddlewareAsync"
        /// <summary>Mies the first middleware asynchronous.</summary>
        /// <param name="context">The context.</param>
        public async Task MyFirstMiddlewareAsync(HttpContext context) =>
            await context.Response.WriteAsync("Hello from 1st public method run method\n");
        #endregion

        #region "MyFirstMapMethod"
        /// <summary>Mies the first map method.</summary>
        /// <param name="app">The application.</param>
        public static void MyFirstMapMethod(IApplicationBuilder app)
        {
            //Use delegate
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from 1st use method in map\n");
                await next();
            });

            // Run delegate
            app.Run(async (context) =>
            await context.Response.WriteAsync("Hello from run method in 1st map"));
        }
        #endregion

        #region "MySecondtMapMethod"
        /// <summary>Mies the secondt map method.</summary>
        /// <param name="app">The application.</param>
        public static void MySecondtMapMethod(IApplicationBuilder app)
        {
            //Use delegate
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from 2nd use method in map\n");
                await next();
            });

            //Run delegate
            app.Run(async (context) =>
            await context.Response.WriteAsync("Hello from run method in 2nd map"));
        }
        #endregion
    }
}
