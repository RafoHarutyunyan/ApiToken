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
    public class SqlRepository : IBaseRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;


        public SqlRepository(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> DeleteProfile<T>(T user)
        {
            var entity = _mapper.Map<T, AppUser>(user);
            await _userManager.FindByEmailAsync(entity.Email);
            entity.IsActivated = false;
            var result = await _userManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        public async Task<bool> SignIn<T>(T user, string password)
        {
            var entity = _mapper.Map<T, AppUser>(user);
            var existUser = await _userManager.FindByEmailAsync(entity.Email);
            var result = await _signInManager.PasswordSignInAsync(entity.Email, password, false, true);
            if(result.Succeeded && existUser.IsActivated)
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
            var entity = _mapper.Map<T,AppUser>(user);
            entity.IsActivated = true;
            var result = await _userManager.CreateAsync(entity, password);

            return result.Succeeded;
        }
    }
}
