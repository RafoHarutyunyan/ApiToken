using App.Core.Identity;
using App.Service.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<SignUp, ApplicationUser>();
            CreateMap<SignIn, ApplicationUser>();
            CreateMap<DeleteUser, ApplicationUser>();

            CreateMap<SignUp, AppUser>();
            CreateMap<SignIn, AppUser>();
            CreateMap<DeleteUser, AppUser>();

            CreateMap<SignUp, Entity>();
            CreateMap<SignIn, Entity>();   
            CreateMap<DeleteUser, Entity>();

            CreateMap<Entity, AppUser>();
            CreateMap<Entity, ApplicationUser>();
        }
    }
}
