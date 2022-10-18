using CoreBussiness.BussinessEntity.RolePermissions;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Roles;

public class Role:Core
{
    public string RoleName { get; set; }
    public ICollection<User>Users { get; set; }
    public ICollection<RolePermission>RolePermissions { get; set; }
}