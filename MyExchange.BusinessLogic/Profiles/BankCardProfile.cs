using AutoMapper;
using MyExchange.Common.Dtos.BankCard;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Profiles
{
    public class BankCardProfile : Profile
    {
        public BankCardProfile()
        {
            CreateMap<BankCard, BankCardDto>();
            CreateMap<BankCardDto, BankCard>();
            CreateMap<BankCardUpdateDto, BankCard>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<long?, long>().ConvertUsing((src, dest) => src ?? dest);
        }
    }
}
