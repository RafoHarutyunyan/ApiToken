using App.Core.Identity;
using App.Repository.Contexts;
using App.Repository.Repository;
using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Extentions
{
    public static class RepositoryFactoryExtention
    {
        public static IServiceCollection AddRepositoryFectory(this IServiceCollection services, Type serviceType, ConfigurationManager configuration)
        {
            var sqlEnabled = configuration.GetValue<bool>("Sql:Enable");
            var mongoEnabled = configuration.GetValue<bool>("Mongo:Enable");
            if (sqlEnabled)
            {
                var connectionSqlString = configuration.GetValue<string>("sql:ConnectionString");
                services.AddDbContext<AppUserDbContext>(opttion => opttion.UseSqlServer(connectionSqlString));
                services.AddIdentity<AppUser, AppRole>(identity =>
                {
                    identity.Password.RequiredLength = 8;
                    identity.Password.RequireNonAlphanumeric = false;
                    identity.Password.RequireUppercase = false;
                }).AddEntityFrameworkStores<AppUserDbContext>()
                .AddDefaultTokenProviders();
                services.AddTransient(serviceType,typeof(SqlRepository));
            }
            else if (mongoEnabled)
            {
                var connectionMongoString = configuration.GetValue<string>("mongo:ConnectionString");
                services
                    .AddIdentityCore<ApplicationUser>()
                    .AddRoles<ApplicationRole>()
                    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(mongo =>
                    {
                        mongo.ConnectionString = connectionMongoString;
                        // other options
                    })/*.AddUserManager<AppUser>().AddSignInManager<AppUser>().AddRoleManager<AppRole>()*/
                    .AddDefaultTokenProviders();

                services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole, Guid>(identity =>
                {
                    identity.Password.RequiredLength = 8;
                    identity.Password.RequireNonAlphanumeric = false;
                    identity.Password.RequireUppercase = false;
                },
                mongo =>
                {
                    mongo.ConnectionString = connectionMongoString;
                });
                services.AddTransient(serviceType, typeof(MongoRepository));
            }
            else
            {
                throw new NullReferenceException("No enabled databsees");
            }
            return services;
        }
    }
}
