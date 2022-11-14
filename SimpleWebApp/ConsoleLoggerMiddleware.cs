public class ConsoleLoggerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        //Here using constructor we can add different services like database, logger etc using dependency injection.

        Console.WriteLine("Before Request");
                await next(context);
                Console.WriteLine("After Request");
    }

}