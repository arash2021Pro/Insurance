namespace CoreBussiness.BussinessEntity.Permissions;

public interface IPermissionService
{
    Task AddNewPermissionAsync(Permission permission);
}