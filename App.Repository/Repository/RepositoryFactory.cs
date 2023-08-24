using App.Core.Identity;
using App.Repository.IRepository;
using App.Repository.IUserRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        //public IUserRepository Instance 
        //{
        //    get 
        //    {
        //        var sqlEnabled = _configuration.GetValue<bool>("Sql:Enabled");
        //        var mongoEnabled = _configuration.GetValue<bool>("Mongo:Enabled");
        //        if (sqlEnabled)
        //        {
        //            var repo = _serviceProvider.GetRequiredService<IUserRepository<AppUser>>();
        //            return repo;
        //        }
        //        else if (mongoEnabled)
        //        {
        //            var repo = _serviceProvider.GetRequiredService<IUserRepository<ApplicationUser>>();
        //        }
        //    }
        //}

        public IBaseRepository Instance
        {
            get
            {
                return null;
                //var sqlEnabled = _configuration.GetValue<bool>("Sql:Enabled");
                //var mongoEnabled = _configuration.GetValue<bool>("Mongo:Enabled");
                //if (sqlEnabled)
                //{
                    
                //    return repo;
                //}
                //else if (mongoEnabled)
                //{
                //    var repo = _serviceProvider.GetRequiredService<IUserRepository<ApplicationUser>>();
                //}
            }
        }
    }
}
