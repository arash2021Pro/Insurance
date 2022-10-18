using System.Security.Claims;
using Blazored.SessionStorage;
using HappyInsurance.BlazorCoreModules.BlazoredSessionStorage;
using HappyInsurance.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HappyInsurance.BlazorCoreModules.CoreAuthenticationService;

public class CustomAuthProvider:AuthenticationStateProvider
{

    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private ClaimsPrincipal _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
    public CustomAuthProvider(ProtectedSessionStorage protectedSessionStorage)
    {
        _protectedSessionStorage = protectedSessionStorage;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var UserSessionStorage = await _protectedSessionStorage.GetAsync<UserSession>("UserSession");
            var UserSession = UserSessionStorage.Success ? UserSessionStorage.Value : null;
            if (UserSession == null)
                return await Task.FromResult(new AuthenticationState(_claimsPrincipal));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity("CustomAuth");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, UserSession.PhoneNumber));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserSession.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, UserSession.Role));
            var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
        catch (Exception e)
        {
            return await Task.FromResult(new AuthenticationState(_claimsPrincipal));
        }
    }
    
    public async Task UpdateAuthenticationStateAsync(UserSession? userSession)
    {
        ClaimsPrincipal claimsPrincipal;
        if (userSession != null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name,userSession.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier,userSession.Id.ToString()),
                new Claim(ClaimTypes.Role,userSession.Role),
         
            }));
            await _protectedSessionStorage.SetAsync("UserSession", userSession);
        }
        else
        {
            claimsPrincipal = _claimsPrincipal;
            await _protectedSessionStorage.DeleteAsync("UserSession");
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}