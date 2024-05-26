
using System.Data.Common;
using sda_onsite_2_csharp_backend_teamwork_The_countryside_developers.src.Exceptions;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers.src.Middlewares
{
    public class CustomErrorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context); // Carry on with the request
            }
            catch (CustomErrorException e)
            {
                context.Response.StatusCode = e.StatusCode;
                context.Response.ContentType = "text/plain";
                Console.WriteLine($"MESSAGE: {e.Message}");
                await context.Response.WriteAsync(e.Message);


            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Error: Something went wrong ! ");
                Console.WriteLine($"ERROR: {e}");

                Console.WriteLine($"ERROR: {e.Message}");

            }

        }
    }
}