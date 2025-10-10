using System.Text.RegularExpressions;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Users
{
    public class Mobile: ValueObject
    {
        public string Value { get; private set; }
        public static bool IsValidMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return false;

            var pattern = @"^09\d{9}$";
            return Regex.IsMatch(mobile, pattern);
        }
        public void SetMobile(string mobile)
        {
            var isValidMobile = IsValidMobile(mobile);
            if (isValidMobile)
                Value = mobile;
            else
                throw new InvalidMobileException();
        }
        public Mobile(string mobile) => SetMobile(mobile);
        public Mobile()
        {
            
        }
    }
}
