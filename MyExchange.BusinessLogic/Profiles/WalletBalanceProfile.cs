using AutoMapper;
using MyExchange.Common.Dtos.WalletBalance;
using MyExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyExchange.BusinessLogic.Profiles
{
    public class WalletBalanceProfile : Profile
    {
        public WalletBalanceProfile()
        {
            CreateMap<WalletBalance, WalletBalanceDto>();
            CreateMap<WalletBalanceDto, WalletBalance>();
            CreateMap<WalletBalanceUpdateDto, WalletBalance>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
        }
    }
}
