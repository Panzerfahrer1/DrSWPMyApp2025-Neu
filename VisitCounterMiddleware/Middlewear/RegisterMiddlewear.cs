using Microsoft.Extensions.Logging;
using VisitCounterMiddleware.Service;

namespace VisitCounterMiddleware.Middlewear
{
    public class RegisterMiddlewear
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RegisterMiddlewear> _logger;

        public RegisterMiddlewear(RequestDelegate next, ILogger<RegisterMiddlewear> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IRegisterService service)
        {
            Console.WriteLine(service.RegisterVisit());

            await _next(context);
        }
    }
}
