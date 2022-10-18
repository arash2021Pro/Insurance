namespace CoreBussiness.BussinessEntity.OneTimePassword;

public interface IOtpService
{
    Task AddNewOtpCodeAsync(OTP otp);
    Task<OTP> GetOtpAsync(string code);
}