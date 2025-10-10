using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Users
{
    public class Email: ValueObject
    {
        public string Value { get;private set; }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
        public void SetEmail(string email)
        {
            var isValidEmail = IsValidEmail(email);
            if (isValidEmail)
                Value = email;
            else
                throw new InvalidEmailException();
        }
        public Email(string email) => SetEmail(email);
        public Email()
        {
            
        }
    }
}
