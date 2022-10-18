using CoreBussiness.BussinessEntity.Plans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfiguration;

public class PlanConfiguration:IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.ImageUrl).IsRequired(false);
    }
}