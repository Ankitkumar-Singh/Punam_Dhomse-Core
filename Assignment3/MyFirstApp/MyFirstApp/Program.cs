using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MyFirstApp
{
    public class Program
    {
        #region "Main"
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        #endregion

        #region "CreateWebHostBuilder"
        /// <summary>Creates the web host builder.</summary>
        /// <param name="args">The arguments.</param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
    }
}
