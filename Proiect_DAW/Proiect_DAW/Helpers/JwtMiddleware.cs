using Proiect_DAW.Helpers.JwtUtilsDir;
using Proiect_DAW.Services.UserService;

namespace Proiect_DAW.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtil)
        {

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtil.GetUserId(token);

            if (userId != null)
            {

                context.Items["User"] = userService.GetUserById(userId.Value);
            }

            await _next(context);
        }
    }
}
