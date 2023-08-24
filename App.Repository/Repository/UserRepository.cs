using App.Core.Identity;
using App.Repository.IUserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Repository
{
    //public class UserRepository : IUserRepository<AppUser>
    //{
    //    private readonly UserManager<AppUser> _userManager;
    //    private readonly RoleManager<AppRole> _roleManager;
    //    private readonly SignInManager<AppUser> _signInManager;
    //    public UserRepository(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    //    {
    //        _roleManager = roleManager;
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    public async Task<bool> SignIn(AppUser user, string password)
    //    {
    //        var result = await _signInManager.PasswordSignInAsync(user.Email, password, false, true);
    //        if(user.IsActivated == true)
    //        {
    //            return result.Succeeded;
    //        }

    //        return false;
            
    //    }

    //    public async Task<bool> SignUp(AppUser user, string password)
    //    {
    //        var result = await _userManager.CreateAsync(user, password);
    //        return result.Succeeded;
    //    }

      
    //    public async Task<bool> DeleteProfile (AppUser user)
    //    {
    //        var result = await _userManager.FindByEmailAsync(user.Email);
            
    //        user.IsActivated = false;
    //        return true;
            
            
    //        //var del = _userManager.DeleteAsync(result);
    //        //return del.IsCompleted;
    //    }

     
    //}
}
