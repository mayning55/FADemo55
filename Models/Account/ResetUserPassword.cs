﻿using System.ComponentModel.DataAnnotations;

namespace FADemo.Models.Account
{
    public class ResetUserPassword
    {
        /// <summary>
        /// 重置密码
        /// </summary>
        [Required]
        public string Id { get; set; }

        [Required]
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
