using CoreBussiness.BussinessEntity.RolePermissions;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Permissions;

public class Permission:Core
{
    public string PermissionName { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}