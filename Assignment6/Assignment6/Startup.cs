using Assignment6.Interfaces;
using Assignment6.MyDbContext;
using Assignment6.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment6
{
    public class Startup
    {
        #region "Private variables"
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration Configuration) => _configuration = Configuration;
        #endregion

        #region "ConfigureServices"
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDBContext>(
                option =>
                option.UseSqlServer(_configuration.GetConnectionString("EmployeeString")));
            services.AddScoped(typeof(IEmployeeRepository),typeof(EmployeeRepoitory));

            services.AddMvc();
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
        }
        #endregion
    }
}
