using App.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.IUserRepository
{
    public interface IUserRepository<T> where T : IEntity
    {
        Task<bool> SignUp(T user, string password);

        Task<bool> SignIn(T user, string password);

        Task<bool> DeleteProfile(T user);

    }
    //public interface IUserRepository
    //{
    //    Task<bool> SignUp(AppUser user, string password);

    //    Task<bool> SignIn(AppUser user, string password);

    //    Task<bool> DeleteProfile(AppUser user);

    //}
}
