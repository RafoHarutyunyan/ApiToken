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
    public class AppUser:IdentityUser<Guid>
    {
        public bool IsActivated { get; set; }
        //public List<string> Roles { get; set; }
        //public List<IdentityUserClaim<string>> Claims { get; set; }
        //public List<IdentityUserLogin<string>> Logins { get; set; }
        //public List<IdentityUserToken<string>> Tokens { get; set; }
    }
}
