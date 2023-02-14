using System.ComponentModel.DataAnnotations;

namespace HousingOutlook2.Models
{
    public class UserLogin
    {
        [Required
      (ErrorMessage = "Incorrect email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Incorrect format: Password must contain a Capital Letter, a number and a special charater")]
        public string Password { get; set; }

        public UserLogin(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public UserLogin()
        {

        }
    }
}
