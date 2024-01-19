using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proiect_DAW.Models;
using Proiect_DAW.Roles;

namespace Proiect_DAW.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Authorize : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;
        public Authorize(params Role[] roles)
        {
            _roles = roles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymous>().Any();
            if (allowAnonymous) return;


            User? user = context.HttpContext.Items["User"] as User;
            if (user == null || _roles.Any() && !_roles.Contains(user.Role))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
