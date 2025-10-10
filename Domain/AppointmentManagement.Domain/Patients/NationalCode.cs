using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Patients
{
    public class NationalCode:ValueObject
    {
        public string Value { get;private set; }
        public NationalCode(string nationalCode)
        {
            SetNationalCode(nationalCode);
        }
        public void SetNationalCode(string nationalCode)
        {
            var isValidNationalCode = IsValidNationalCode(nationalCode);
            if (isValidNationalCode)
                Value = nationalCode;
            else
                throw new InvalidNationalCodeException();
        }

        public bool IsValidNationalCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length != 10 || !code.All(char.IsDigit))
                return false;

            var invalidCodes = new[]
            {
        "0000000000", "1111111111", "2222222222", "3333333333",
        "4444444444", "5555555555", "6666666666", "7777777777",
        "8888888888", "9999999999"
    };
            if (invalidCodes.Contains(code))
                return false;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (code[i] - '0') * (10 - i);
            }

            int remainder = sum % 11;
            int checkDigit = code[9] - '0';

            return (remainder < 2 && checkDigit == remainder) ||
                   (remainder >= 2 && checkDigit == 11 - remainder);
        }
        public NationalCode()
        {
            
        }
    }
}
