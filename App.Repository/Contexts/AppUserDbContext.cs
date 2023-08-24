using App.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Contexts;

public class AppUserDbContext : IdentityDbContext<AppUser,AppRole, Guid>
{
    public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options) { }
}
