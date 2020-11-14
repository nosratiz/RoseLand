using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OnlineShop.UI.Middleware
{
    /// <summary>
    ///  OnExceptionMiddleware , Produce Custom message during Internal Server Exception
    /// </summary>
    public class OnExceptionMiddleware : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        public OnExceptionMiddleware(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <inheritdoc />
        public void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message, context.Exception.StackTrace);
        }
    }
}