using CoreApplication.CoreManagementApplication;
using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class Permission : ComponentBase
{ 
    [Inject] private IHttpContextAccessor _contextAccessor { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private ICoreManagerService _coreManagerService { get; set; } 
    private string Login { get; set; } = "/Login"; 
    private string Logout { get; set; } = "/";
    
    public async Task CheckPermission()
    {
        
        if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var Phonenumber = _contextAccessor.HttpContext.User.Identity.Name;
            var RoleId = _coreManagerService.UserService.GetUserAsyncByPhoneNumber(Phonenumber);
            if (!await _coreManagerService.RolePermissionService.HasPermissionAsync(RoleId, 1))
            {
                _navigationManager.NavigateTo(Login);
            }
        }
        else
        {
            _navigationManager.NavigateTo("/");
        }
    }
}