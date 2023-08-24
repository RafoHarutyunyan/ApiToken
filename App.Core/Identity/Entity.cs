using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Identity
{
    public class Entity : IEntity
    {
        [IgnoreDataMember]
        [NotMapped]
        public bool IsActivated { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string UserName { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string NormalizedUserName { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string Email { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string NormalizedEmail { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public bool EmailConfirmed { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string PasswordHash { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string SecurityStamp { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string ConcurrencyStamp { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public string PhoneNumber { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public bool PhoneNumberConfirmed { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public bool TwoFactorEnabled { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public DateTimeOffset? LockoutEnd { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public bool LockoutEnabled { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public int AccessFailedCount { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public List<string> Roles { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public List<IdentityUserClaim<string>> Claims { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public List<IdentityUserLogin<string>> Logins { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        public List<IdentityUserToken<string>> Tokens { get; set; }
    }
}
