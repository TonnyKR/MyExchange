using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExchange.Data.Entities;
using MyExchange.Common.Dtos.User;

namespace MyExchange.BusinessLogic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
        }
    }
}
