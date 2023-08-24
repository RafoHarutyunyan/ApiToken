using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.IRepository
{
    public interface IBaseRepository
    {
        Task<bool> SignUp<T>(T user, string password);

        Task<bool> SignIn<T>(T user, string password);

        Task<bool> DeleteProfile<T>(T user);
    }
}
