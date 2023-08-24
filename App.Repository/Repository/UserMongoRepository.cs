using App.Core.Identity;
using App.Repository.IUserRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Repository
{
    //public class UserMongoRepository : IUserRepository<ApplicationUser>
    //{

    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly RoleManager<ApplicationRole> _roleManager;
    //    private readonly SignInManager<ApplicationUser> _signInManager;
    //    public UserMongoRepository(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    //    {
    //        _roleManager = roleManager;
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }


    //    public async Task<bool> SignIn(ApplicationUser user, string password)
    //    {
    //        var result = await _signInManager.PasswordSignInAsync(user.Email, password, false, true);
    //        if (user.IsActivated == true)
    //        {
    //            return result.Succeeded;
    //        }

    //        return false;

    //    }


    //    public async Task<bool> SignUp(ApplicationUser user, string password)
    //    {
    //        var result = await _userManager.CreateAsync(user, password);
    //        return result.Succeeded;
    //    }


    //    public async Task<bool> DeleteProfile(ApplicationUser user)
    //    {
    //        var result = await _userManager.FindByEmailAsync(user.Email);

    //        user.IsActivated = false;
    //        return true;


    //        //var del = _userManager.DeleteAsync(result);
    //        //return del.IsCompleted;
    //    }
    //}
}
