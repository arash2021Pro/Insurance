using CoreBussiness.BussinessEntity.Orders;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Plans;

public class Plan:Core
{
    public int Price { get; set; }
    public string?Description { get; set; }
    public PlanType PlanType { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<Order>Orders { get; set; }
    public int PlanCount { get; set; }
    public int Discount { get; set; }
}