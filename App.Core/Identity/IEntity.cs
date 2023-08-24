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
    public interface IEntity
    {
        [IgnoreDataMember]
        [NotMapped]
        bool IsActivated { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string UserName { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string NormalizedUserName { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string Email { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string NormalizedEmail { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        bool EmailConfirmed { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string PasswordHash { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string SecurityStamp { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string ConcurrencyStamp { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        string PhoneNumber { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        bool PhoneNumberConfirmed { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        bool TwoFactorEnabled { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        DateTimeOffset? LockoutEnd { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        bool LockoutEnabled { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        int AccessFailedCount { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        List<string> Roles { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        List<IdentityUserClaim<string>> Claims { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        List<IdentityUserLogin<string>> Logins { get; set; }
        [IgnoreDataMember]
        [NotMapped]
        List<IdentityUserToken<string>> Tokens { get; set; }

    }
}
