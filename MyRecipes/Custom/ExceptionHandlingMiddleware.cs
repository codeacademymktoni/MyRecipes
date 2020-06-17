using Microsoft.AspNetCore.Http;
using MyRecipes.Services.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyRecipes.Custom
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogsService logsService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                var logMessage = new {
                    HttpRequestPath = httpContext.Request.Path,
                    Exception = ex };

                logsService.Log("Global", JsonConvert.SerializeObject(logMessage));

                throw;
            }
        }
    }
}
