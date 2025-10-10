using System.Security.Cryptography;
using System.Text;

namespace AppointmentManagement.Application
{
    public static class OtpManager
    {
        private static readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStore = new();

        public static string GenerateOtp(string mobile, int length = 4, int expiryMinutes = 5)
        {
            var otp = GenerateSecureOtp(length);
            var expiry = DateTime.UtcNow.AddMinutes(expiryMinutes);

            _otpStore[mobile] = (otp, expiry);
            return otp;
        }

        public static bool ValidateOtp(string mobile, string inputOtp)
        {
            if (_otpStore.TryGetValue(mobile, out var entry))
            {
                if (DateTime.UtcNow > entry.Expiry)
                {
                    _otpStore.Remove(mobile); // expired
                    throw new Exception();
                }

                if (entry.Otp == inputOtp)
                {
                    _otpStore.Remove(mobile); // one-time use
                    return true;
                }
            }

            throw new Exception();
        }

        private static string GenerateSecureOtp(int length)
        {
            var otp = new StringBuilder();
            using var rng = RandomNumberGenerator.Create();
            byte[] buffer = new byte[1];

            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(buffer);
                otp.Append(buffer[0] % 10);
            }

            return otp.ToString();
        }
    }

}
