namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfilePicture
    {
        public string Id { get; set; }

        public DateTime UploadDate { get; set; }

        public byte[] Content { get; set; }

        public string UntrustedName { get; set; }

        public double Size { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
