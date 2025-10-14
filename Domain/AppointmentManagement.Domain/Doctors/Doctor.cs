using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Doctors.DoctorExperts;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Domain.SystemUsers;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Doctors
{
    public class Doctor : User
    {

        public Doctor()
        { }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
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
        public Doctor(string firstName, string lastName, Email email, Mobile mobile, string password, Location location) :
            base(firstName, lastName, email, mobile, RoleType.Doctor)
        {
            CreatePasswordHash(password);
            Location = location;
        }
        public void Update(string firstName, string lastName, Mobile mobile, Location location)
        {
            Location = location;
            base.Update(firstName,  lastName,  mobile);
        }
        public void AssignDoctorExperts(List<DoctorExpert> doctorExperts)
        {
            DoctorExperts = doctorExperts;
        }

        public List<DoctorExpert> DoctorExperts { get; private set; }
        public Location Location { get; private set; }
        public List<DoctorDefaultSchedule> DefaultSchedules { get; private set; }
        public List<DoctorOverrideSchedule> OverrideSchedules { get; private set; }

    }
    public class Location
    {
        public string Name { get;private set; }
        public string Province { get; private set; }
        public string EnglishName { get; private set; }
        public Location(string name,string province,string englishName)
        {
            Name = name;
            Province = province;
            EnglishName = englishName;
        }
    }
}
