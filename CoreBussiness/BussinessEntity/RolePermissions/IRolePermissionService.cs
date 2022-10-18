namespace CoreBussiness.BussinessEntity.RolePermissions;

public interface IRolePermissionService
{
    Task AddNewRolePermissionAsync(RolePermission rolePermission);
    Task<bool> HasPermissionAsync(int RoleId, int PermissionId);
}