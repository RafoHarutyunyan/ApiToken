using App.Core.Identity;
using App.Repository.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.IRepository
{
    public interface IRepositoryFactory
    {
        IBaseRepository Instance { get;}          
    }
}
