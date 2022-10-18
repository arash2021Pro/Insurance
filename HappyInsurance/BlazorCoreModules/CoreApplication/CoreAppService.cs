using Blazored.SessionStorage;
using CoreApplication.CoreManagementApplication;
using CoreApplication.LogApplication;
using CoreApplication.OtpApplication;
using CoreApplication.PermissionApplication;
using CoreApplication.ReferralApplication;
using CoreApplication.RoleApplication;
using CoreApplication.RolePermissionApplication;
using CoreApplication.UserApplication;
using CoreApplication.WalletApplication;
using CoreBussiness.BussinessEntity.Logs;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.BussinessEntity.Permissions;
using CoreBussiness.BussinessEntity.Refferals;
using CoreBussiness.BussinessEntity.RolePermissions;
using CoreBussiness.BussinessEntity.Roles;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.BussinessEntity.Wallets;
using CoreBussiness.RepsPattern;
using CoreInfraSructure.CoreEmailServices;
using CoreInfraSructure.CoreMessageServices;
using CoreStorage.StorageContext;
using HappyInsurance.BlazorCoreModules.CoreAuthenticationService;
using HappyInsurance.BlazorCoreModules.CoreComponents;
using HappyInsurance.BlazorCoreModules.CoreSqlserverInitialization;
using HappyInsurance.BlazorCoreModules.FileHandlerManager;
using HappyInsurance.BlazorCoreModules.RandomeGenerator;
using MapsterMapper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HappyInsurance.BlazorCoreModules.CoreApplication;

public static class CoreAppService
{
    public static void SetCoreAppService(this IServiceCollection service)
    {
        service.AddScoped<IMapper,Mapper>();
        service.AddScoped<IUnitOfWork, ApplicationContext>();
        service.AddScoped<ICodeGeneratorService, CodeGenerator>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<ICoreManagerService, CoreManagerService>();
        service.AddScoped<IMessageService, MessageService>();
        service.AddScoped<IRoleService, RoleService>();
        service.AddScoped<IPermissionService, PermissionService>();
        service.AddScoped<IRolePermissionService, RolePermissionService>();
        service.AddScoped<IDatabaseInitialization, DatabaseInitialService>();
        service.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        service.AddScoped<IOtpService, OtpService>();
        service.AddScoped<ILogService, LogService>();
        service.AddScoped<IEmailService, EmailService>();
        service.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
        service.AddScoped<ProtectedSessionStorage>();
        service.AddScoped<IReferralService, ReferralService>();
        service.AddScoped<IFileHandlerService, FileManagerService>();
        service.AddScoped<IWalletService, WalletService>();
        service.AddHttpClient();
    }
}