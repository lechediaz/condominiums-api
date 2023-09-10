using Microsoft.AspNetCore.Authorization;
using NamiSic.Api.Auth.Requirements;
using NamiSic.Api.Constants;

namespace NamiSic.Api.Auth.Handlers;

/// <summary>
/// Validates if authenticated user has a role assigned.
/// </summary>
public class RoleHandler : AuthorizationHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {

        string[] roles = requirement.Roles;

        if (context.User.HasClaim(claim => claim.Type == ClaimName.Role && roles.Contains(claim.Value)))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
