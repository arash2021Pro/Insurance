using CoreBussiness.BussinessEntity.RolePermissions;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.RolePermissionApplication;

public class RolePermissionService:IRolePermissionService
{
    private DbSet<RolePermission> _rolePermissions;
    public RolePermissionService(IUnitOfWork work)
    {
        _rolePermissions = work.Set<RolePermission>();
    }

    public async Task AddNewRolePermissionAsync(RolePermission rolePermission) =>
        await _rolePermissions.AddAsync(rolePermission);

    public async Task<bool> HasPermissionAsync(int RoleId, int PermissionId)
    {
        return await _rolePermissions.AnyAsync(
            x => x.RoleId == RoleId && x.PermissionId == PermissionId && !x.IsDeleted);
    }
}