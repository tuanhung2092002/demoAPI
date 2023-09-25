namespace demoWebAPI.Middleware
{
    public class FirstMiddleware
    {

        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            DateTime Time = DateTime.Now;

            string StringTime = Time.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine($"Time: {StringTime}");

            Console.WriteLine($"URL: {context.Request.Path}");
           

            await _next(context);
        }
    }
}
