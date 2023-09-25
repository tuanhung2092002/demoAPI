namespace demoWebAPI.Middleware
{
    public class RequestLogging
    {
        private readonly RequestDelegate _next;

        public RequestLogging(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Ghi log trước khi xử lý yêu cầu
            Console.WriteLine($"Request received: {context.Request.Method} {context.Request.Path}");

            // Chuyển yêu cầu đến middleware tiếp theo trong pipeline
            await _next(context);

            // Ghi log sau khi xử lý yêu cầu
            Console.WriteLine($"Response sent: {context.Response.StatusCode}");
        }
    }
}
