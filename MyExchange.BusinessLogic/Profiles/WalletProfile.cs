using AutoMapper;
using MyExchange.BusinessLogic.Dtos.Wallet;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, WalletDto>();
            CreateMap<WalletDto, Wallet>();
            CreateMap<WalletUpdateDto, Wallet>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
