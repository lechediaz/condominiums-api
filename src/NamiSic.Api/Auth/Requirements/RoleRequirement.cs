using Microsoft.AspNetCore.Authorization;

namespace NamiSic.Api.Auth.Requirements;

/// <summary>
/// Requirement to validate role claim.
/// </summary>
public class RoleRequirement : IAuthorizationRequirement
{
    public RoleRequirement(string[] roles)
    {
        Roles = roles;
    }

    public string[] Roles { get; }
}
