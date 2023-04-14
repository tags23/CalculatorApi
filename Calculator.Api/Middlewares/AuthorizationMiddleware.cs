namespace Calculator.Api.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string AllowedApiKey = "8c066128-ac81-4f7a-a956-1f9930bf477e";

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var headers = context.Request.Headers;
            var isApiKeyPresent = headers.TryGetValue("ApiKey", out var apiKey);

            if (!isApiKeyPresent || apiKey != AllowedApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
