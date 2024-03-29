﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MVCUsingAspDotnetCore.Repositories;
using MVCUsingAspDotnetCore.RepositoryInterfaces;

namespace MVCUsingAspDotnetCore
{
    public class Startup
    {
        #region "ConfigureServices"
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(typeof(IEmpoyeeRepository), typeof(MockEmployeeRepository));
        }
        #endregion

        #region "Configure"
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
        }
        #endregion
    }
}
