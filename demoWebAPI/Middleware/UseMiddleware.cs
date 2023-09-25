namespace demoWebAPI.Middleware
{
    public static class UseMiddlewareMethod
    {
        public static void UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
    }
}
