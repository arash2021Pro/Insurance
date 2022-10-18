using CoreBussiness.BussinessEntity.Refferals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfiguration;

public class ReferralConfiguration:IEntityTypeConfiguration<Refferal>
{
    public void Configure(EntityTypeBuilder<Refferal> builder)
    {
        builder.HasOne(x => x.User).WithMany(x => x.Refferals).HasForeignKey(x => x.UserId);
        builder.Property(x => x.PhoneNumber).IsRequired(false);
        builder.Property(x => x.ReferralCount).HasDefaultValue(0);
    }
}