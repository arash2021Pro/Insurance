using System.Security.AccessControl;
using CoreApplication.CoreManagementApplication;
using CoreApplication.UserApplication;
using HappyInsurance.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class LoginComponent:ComponentBase
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject]private AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject]private IJSRuntime _jsRuntime { get; set; }
    [Inject]private ICoreManagerService _coreManagerService { get; set; }
    public string Message { get; set; }

    public async Task LoginAsync(LoginModel loginModel)
    {

        var IsCompleted = true;
        var user = await _coreManagerService.UserService.GetUserAsync(loginModel.Phonenumber,loginModel.Password);
        if (user == null)
        {
            Message = "user not found";
            IsCompleted = false;
        }
        if (IsCompleted)
        { 
            var CustomAuthProvider = (CoreAuthenticationService.CustomAuthProvider) _authenticationStateProvider;
            await CustomAuthProvider.UpdateAuthenticationStateAsync(new UserSession()
                {Id = user.Id, Role = user.Role.RoleName, PhoneNumber = user.PhoneNumber});
            _navigationManager.NavigateTo("/",true);
        }
    }

   
}