using CoreApplication.CoreManagementApplication;
using HappyInsurance.BlazorCoreModules.CoreAuthenticationService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class BussinessComponent:ComponentBase
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject] private ICoreManagerService _coreManagerService { get; set; }
    public string ?Code { get; set; }
    public async Task GoToGetRefAsync()
    {
        var claimAuthState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = await _coreManagerService.UserService.GetUserAsyncByIdAsync(claimAuthState.User.GetCurrentUserId());
        Code = user?.UserCode;
    }
}