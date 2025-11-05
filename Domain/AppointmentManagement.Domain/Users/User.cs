using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Users
{
    public abstract class User:AuditableEntityBase<long>,IAggrigateRoot
    {
        protected User()
        {

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{FirstName} {LastName}";
        public Email? Email { get; private set; }//Username
        public Mobile Mobile { get; private set; }
        public RoleType Role { get; private set; }
        public bool IsActive { get; private set; }
        public User(string firstName, string lastName, Email email, Mobile mobile,RoleType role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
            IsActive = true;
            Role = role;
        }
        public User(string firstName, string lastName, Mobile mobile, RoleType role)
        {
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            IsActive = true;
            Role = role;
        }
        public void Update(string firstName, string lastName, Mobile mobile)
        {
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
        } 
        public void Update(string firstName, string lastName, Email email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public void Activate()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }

    }
    public class TestUser: User
    {
        public TestUser()
        {
            
        }
        public TestUser(string firstName, string lastName, Email email, Mobile mobile,RoleType role):
            base( firstName,  lastName,  email,  mobile, role)
        {
            
        }
    }
}
