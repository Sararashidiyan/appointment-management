using System.Data;
using System.Security.Cryptography;
using System.Text;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.SystemUsers
{
    public class SystemUser : User
    {
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public bool IsSupperAdmin { get;private set; }
        public bool VerifyPassword(string password)
        {
            return PasswordHelper.VerifyPassword(password, PasswordHash, PasswordSalt);
        }
        public void CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        public static SystemUser CraeteSupperAdmin(string firstName, string lastName, Email email, Mobile mobile)
        {
            var password = "Admin@123";
            var user= new SystemUser(firstName, lastName, email, mobile, RoleType.Admin, password);
            user.IsSupperAdmin = true;
            return user;
        }

        public SystemUser(string firstName, string lastName, Email email, Mobile mobile, RoleType role, string password)
            : base(firstName, lastName, email, mobile, role)
        {
            CreatePasswordHash(password);
        }
        public SystemUser()
        {

        }
    }

}
