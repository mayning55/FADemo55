using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace FADemo.Models.Account
{
    public class CreateUser
    {
        [Required]
        [Remote(action: "IsUserNameAvailable", controller: "User")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
