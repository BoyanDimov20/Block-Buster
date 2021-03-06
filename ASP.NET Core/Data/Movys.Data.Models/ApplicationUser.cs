﻿// ReSharper disable VirtualMemberCallInConstructor
namespace Movys.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using Movys.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.MovieWatchList = new HashSet<MoviesUser>();
            this.Reviews = new HashSet<Review>();
            this.Comments = new HashSet<Comment>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        // Additional info
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<MoviesUser> MovieWatchList { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }

        public string ProfilePictureId { get; set; }
    }
}
