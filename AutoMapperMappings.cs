using AutoMapper;
using RealState.Data.Entities;
using RealState.Web.ViewModels;
using System.Data;

namespace RealState.Web
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            //CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
