using System.Security.Claims;
using CoreApplication.CoreManagementApplication;
using CoreBussiness.BussinessEntity.Logs;
using CoreBussiness.RepsPattern;
using HappyInsurance.BlazorCoreModules.CoreAuthenticationService;
using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class Logger:ComponentBase
{
    [Inject] private IHttpContextAccessor _contextAccessor { get; set; }
    [Inject] private ICoreManagerService _coreManagerService { get; set; }
    [Inject] private IUnitOfWork _work { get; set; }
    private Log Log { get; set; } = new();
    
    public async Task SetLogAsync()
    {
        Log.BrowserName = _contextAccessor.HttpContext.Request.Headers["user-agent"].ToString();
        Log.PhoneNumber = _contextAccessor.HttpContext.User.Identity.Name;
        Log.RoleName = _contextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        Log.UserId = _contextAccessor.HttpContext.User.GetCurrentUserId();
        await _coreManagerService.LogService.AddNewLogAsync(Log);
        await _work.SaveChangesAsync();
    }
    
}