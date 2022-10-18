using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.OtpApplication;

public class OtpService:IOtpService
{
    private DbSet<OTP> _otps;
    public OtpService(IUnitOfWork work)
    {
        _otps = work.Set<OTP>();
    }

    public async Task AddNewOtpCodeAsync(OTP otp) => await _otps.AddAsync(otp);
    public async Task<OTP?> GetOtpAsync(string code) => await _otps.AsTracking().FirstOrDefaultAsync(x => x.code == code);

}