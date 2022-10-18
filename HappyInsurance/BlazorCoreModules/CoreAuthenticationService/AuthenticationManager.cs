using System.Security.Claims;

namespace HappyInsurance.BlazorCoreModules.CoreAuthenticationService;

public static class AuthenticationManager
{
    
    public static int GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
    {
        
        var userId = 0;
        try
        {
            userId = int.Parse(claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }
        catch (Exception e)
        {
            
        }
        return userId;
        
    }
}