using CoreBussiness.BussinessEntity.Logs;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.BussinessEntity.Permissions;
using CoreBussiness.BussinessEntity.Refferals;
using CoreBussiness.BussinessEntity.RolePermissions;
using CoreBussiness.BussinessEntity.Roles;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.BussinessEntity.Wallets;

namespace CoreApplication.CoreManagementApplication;

public class CoreManagerService:ICoreManagerService
{
    public CoreManagerService(IUserService userService, IRoleService roleService, IPermissionService permissionService, IRolePermissionService rolePermissionService, IOtpService otpService, ILogService logService, IReferralService referralService)
    {
        UserService = userService;
        RoleService = roleService;
        PermissionService = permissionService;
        RolePermissionService = rolePermissionService;
        OtpService = otpService;
        LogService = logService;
        ReferralService = referralService;
    }

    public IUserService UserService { get; set; }
    public IRoleService RoleService { get; set; }
    public IPermissionService PermissionService { get; set; }
    public IRolePermissionService RolePermissionService { get; set; }
    public IOtpService OtpService { get; set; }
    public ILogService LogService { get; set; }
    public IReferralService ReferralService { get; set; }
    
    public IWalletService WalletService { get; set; }
}