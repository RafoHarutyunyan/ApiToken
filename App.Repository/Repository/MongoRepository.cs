using App.Core.Identity;
using App.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Repository
{
    public class MongoRepository : IBaseRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public MongoRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> DeleteProfile<T>(T user)
        {
            var entity = _mapper.Map<T, ApplicationUser>(user);
            await _userManager.FindByEmailAsync(entity.Email);
            entity.IsActivated = false;
            var result = await _userManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        public async Task<bool> SignIn<T>(T user, string password)
        {
            var entity = _mapper.Map<T, ApplicationUser>(user);
            var existUser = await _userManager.FindByEmailAsync(entity.Email);
            var result = await _signInManager.PasswordSignInAsync(entity.Email, password, false, true);
            if (result.Succeeded && existUser.IsActivated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SignUp<T>(T user, string password)
        {
            var entity = _mapper.Map<T, ApplicationUser>(user);
            entity.IsActivated = true;
            var result = await _userManager.CreateAsync(entity, password);
            return result.Succeeded;
        }
    }
}
