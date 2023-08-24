using App.Core.Identity;
using App.Repository.IRepository;
using App.Repository.IUserRepository;
using App.Service.Commands;
using App.Service.IService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Services;

public class UserService : IUserService
{
    //private readonly IUserRepository _userRepository;
    private readonly IBaseRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IBaseRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<bool> SignUp(SignUp signUp)
    {
        var data = _mapper.Map<Entity>(signUp);
        data.UserName = signUp.Email;
        var result = await _userRepository.SignUp(data, signUp.Password);
        return result;
    }

    public async Task<bool> SignIn(SignIn signIn)
    {
        var data = _mapper.Map<Entity>(signIn);
        var result = await _userRepository.SignIn(data, signIn.Password);

        return result;
    }


    public async Task<bool> DeleteProfile(DeleteUser user)
    {
        var data = _mapper.Map<Entity>(user);
        var result = await _userRepository.DeleteProfile(data);

        return result;
    }


}
