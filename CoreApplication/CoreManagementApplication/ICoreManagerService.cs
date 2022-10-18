using CoreBussiness.BussinessEntity.Logs;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.BussinessEntity.Permissions;
using CoreBussiness.BussinessEntity.Refferals;
using CoreBussiness.BussinessEntity.RolePermissions;
using CoreBussiness.BussinessEntity.Roles;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.BussinessEntity.Wallets;
using Mapster;

namespace CoreApplication.CoreManagementApplication;

public interface ICoreManagerService
{
    public IUserService UserService { get; set; }
    public IRoleService RoleService { get; set; }
    public IPermissionService PermissionService { get; set; }
    public IRolePermissionService RolePermissionService { get; set; }
    public IOtpService OtpService { get; set; }
    public ILogService LogService { get; set; }
    public IReferralService ReferralService { get; set; }
    public IWalletService WalletService { get; set; }
}