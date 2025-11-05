using System;
using System.Security.Cryptography;
using System.Text;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.OTPGenerator;

namespace AppointmentManagement.Infrastructure.OTPGenerator
{
    public class OtpGenerator : IOtpGenerator
    {
        private static readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStore = new();

        public  string GenerateOtp(string mobile, int length = 4, int expiryMinutes = 5)
        {
            var otp = GenerateSecureOtp(length);
            var expiry = DateTime.UtcNow.AddMinutes(expiryMinutes);

            _otpStore[mobile] = (otp, expiry);
            return otp;
        }

        public bool ValidateOtp(string mobile, string inputOtp)
        {
            if (!_otpStore.TryGetValue(mobile, out var entry))
                throw new NoOTPFoundExpiration();

            if (DateTime.UtcNow > entry.Expiry)
            {
                _otpStore.Remove(mobile, out _);
                throw new OtpExpirationException();
            }

            if (entry.Otp != inputOtp)
                throw new InvalidOtpException();

            _otpStore.Remove(mobile, out _); // One-time use
            return true;
        }

        private  string GenerateSecureOtp(int length)
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
