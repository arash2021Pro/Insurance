using CoreBussiness.BussinessEntity.Logs;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.LogApplication;

public class LogService:ILogService
{
    private DbSet<Log> _logs;
    public LogService(IUnitOfWork work)
    {
        _logs = work.Set<Log>();
    }

    public async Task AddNewLogAsync(Log log) => await _logs.AddAsync(log);
}