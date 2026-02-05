namespace _02MovieList.Middlewear
{
    public class LoggingMiddlewear
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggingMiddlewear> logger;

        public LoggingMiddlewear(RequestDelegate next, ILogger<LoggingMiddlewear> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation(context.Request.Method);
            logger.LogInformation(context.Request.Path);
            logger.LogInformation(context.Request.HttpContext.Connection.RemoteIpAddress.ToString());
            await next(context);
            //logger.LogInformation("response...");
        }
    }
}
