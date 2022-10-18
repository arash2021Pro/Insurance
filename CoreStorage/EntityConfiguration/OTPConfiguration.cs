using CoreBussiness.BussinessEntity.OneTimePassword;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfiguration;

public class OTPConfiguration:IEntityTypeConfiguration<OTP>
{
    public void Configure(EntityTypeBuilder<OTP> builder)
    {
        builder.HasOne(x => x.User).WithMany(x => x.Otps).HasForeignKey(x => x.UserId);
        builder.Property(x => x.code).IsRequired().HasMaxLength(5);
    }
}