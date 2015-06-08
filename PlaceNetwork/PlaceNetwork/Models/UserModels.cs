using System.ComponentModel.DataAnnotations;

namespace PlaceNetwork.Models
{
    public class UserLoginModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserRegistrationModel
    {
        [Required]
        [Display(Name = "Login")]
        [MaxLength(20, ErrorMessage = "Login can not be longer than 20 characters.")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(4, ErrorMessage = "Password can not be shorter than 4 characters.")]
        [MaxLength(50, ErrorMessage = "Password can not be longer than 50 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Email can not be longer than 50 characters.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Displayed username")]
        [MaxLength(20, ErrorMessage = "UserName can not be longer than 20 characters.")]
        public string UserName { get; set; }
    }
}
