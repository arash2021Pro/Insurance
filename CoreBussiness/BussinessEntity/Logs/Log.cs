using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Logs;

public class Log:Core
{
    public string? BrowserName { get; set; }
    public string? Action { get; set; }
    public string ?PhoneNumber { get; set; }
    public string ?RoleName { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}