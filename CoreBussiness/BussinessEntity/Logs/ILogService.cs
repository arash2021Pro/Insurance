namespace CoreBussiness.BussinessEntity.Logs;

public interface ILogService
{
    Task AddNewLogAsync(Log log);
}