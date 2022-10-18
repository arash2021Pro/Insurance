using CoreBussiness.BussinessEntity.Roles;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.RoleApplication;

public class RoleService:IRoleService
{
    private DbSet<Role> _roles;
    public RoleService(IUnitOfWork work)
    {
        _roles = work.Set<Role>();
    }

    public async Task AddNewRoleAsync(Role role) => await _roles.AddAsync(role);

}