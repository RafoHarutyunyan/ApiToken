using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Identity
{
    public class ApplicationUser : MongoUser<Guid>
    {
        public bool IsActivated { get; set; } 
    }
}
