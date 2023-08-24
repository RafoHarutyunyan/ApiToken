using App.Service.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.IService
{
    public interface IUserService
    {
        Task<bool> SignUp(SignUp signUp);
        Task<bool> SignIn(SignIn signIn);
        Task<bool> DeleteProfile(DeleteUser user);

    }
}
