using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyFirstApp.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        #region "Private variables"
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        #endregion

        #region "MyMiddleware"
        /// <summary>Initializes a new instance of the <see cref="MyMiddleware"/> class.</summary>
        /// <param name="next">The next.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public MyMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Mymiddleware");
        }
        #endregion

        #region "Invoke"
        /// <summary>Invokes the specified HTTP context.</summary>
        /// <param name="httpContext">The HTTP context.</param>
        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Mymiddleware executing..");
            await _next(httpContext);
        }
        #endregion
    }

    #region "MyMiddlewareExtensions"
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder) =>  builder.UseMiddleware<MyMiddleware>();
    }
    #endregion
}
