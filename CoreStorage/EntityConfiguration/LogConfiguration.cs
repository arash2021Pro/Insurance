using CoreBussiness.BussinessEntity.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfiguration;

public class LogConfiguration:IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.Property(x => x.Action).IsRequired(false);
        builder.Property(x => x.BrowserName).IsRequired(false);
        builder.Property(x => x.PhoneNumber).IsRequired(false);
        builder.Property(x => x.RoleName).IsRequired(false);
        builder.HasOne(x => x.User).WithMany(x => x.Logs).HasForeignKey(x => x.UserId);
    }
}