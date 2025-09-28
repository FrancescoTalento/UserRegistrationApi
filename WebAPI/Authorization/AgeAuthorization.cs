using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(
                c => c.Type == ClaimTypes.DateOfBirth);
            if (dateOfBirthClaim == null) return Task.CompletedTask;

            DateTime dateOfBirthValue = Convert.ToDateTime(dateOfBirthClaim.Value);

            int age = DateTime.Today.Year - dateOfBirthValue.Year;
            
            if(dateOfBirthValue > DateTime.Today.AddYears(-age))
            {
                age--;
            };

            if (age > requirement.Age) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
