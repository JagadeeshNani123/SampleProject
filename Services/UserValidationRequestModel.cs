using SampleProject.Models;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.Services
{
    public class UserValidationRequestModel
    {
        private readonly SampleProjectContext _context = new SampleProjectContext();
       
        public string EmailAddress { get; set; }
       
        public string Password { get; set; }


        public UserValidationRequestModel(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }


        public UserRegistration GetUser()
        {
            return _context.UserRegistration.FirstOrDefault(user => user.EmailAddress == EmailAddress && user.Password == Password);
        }
        public bool IsValidUser()
        {
            return _context.UserRegistration.Any(user => user.EmailAddress == EmailAddress && user.Password == Password);
        }
    }
}
