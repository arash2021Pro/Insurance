using CoreBussiness.BussinessEntity.Permissions;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.PermissionApplication;

public class PermissionService:IPermissionService
{
    private DbSet<Permission> _permissions;
    public PermissionService(IUnitOfWork work)
    {
        _permissions = work.Set<Permission>();
    }

    public async Task AddNewPermissionAsync(Permission permission) => await _permissions.AddAsync(permission);

}