namespace Movys.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SubscriptionViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
