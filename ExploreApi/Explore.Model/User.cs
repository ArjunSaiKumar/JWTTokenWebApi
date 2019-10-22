using System;
using System.Collections.Generic;

namespace Explore.Model
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
            this.IsActive = true;
            this.CreationDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string category { get; set; }
        public string Address1 { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public virtual User Manager { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public bool IsActive { get; set; }

        public int? CreatedById { get; set; }
        public virtual User CreatedByUser { get; set; }

        public DateTime CreationDate { get; set; }

        public int? UpdatedById { get; set; }
        public virtual User UpdatedByUser { get; set; }

        public DateTime? UpdatedDate { get; set; }
        
        public bool IsConnectionsEnabled { get; set; }

        public int? DeactivatedBy { get; set; }

        public virtual User DeactivatedByUser { get; set; }
        public DateTime? DeactivatedDate { get; set; }
    }
}
