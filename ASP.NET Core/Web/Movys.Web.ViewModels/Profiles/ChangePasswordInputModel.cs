namespace Movys.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ChangePasswordInputModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols.")]
        public string NewPassword { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords should match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
