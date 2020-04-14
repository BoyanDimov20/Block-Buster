namespace Movys.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateCommentInputModel
    {
        [Required]
        [MinLength(115, ErrorMessage = "Your comment is too short.")]
        public string Content { get; set; }
    }
}
