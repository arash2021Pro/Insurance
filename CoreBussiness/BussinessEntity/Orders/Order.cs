using CoreBussiness.BussinessEntity.Plans;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Orders;

public class Order:Core
{
    public int PlanId { get; set; }
    public Plan Plan { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int TotalPrice { get; set; }
}