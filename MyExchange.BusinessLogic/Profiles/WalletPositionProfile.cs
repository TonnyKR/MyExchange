using AutoMapper;
using MyExchange.Common.Dtos.WalletPosition;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Profiles
{
    public class WalletPositionProfile : Profile
    {
        public WalletPositionProfile()
        {
            CreateMap<WalletPosition, WalletPositionDto>();
            CreateMap<WalletPositionDto, WalletPosition>();
            CreateMap<WalletPositionUpdateDto, WalletPosition>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<WalletPositionUpdateDto, WalletPositionDto>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<WalletPositionDto, WalletPositionUpdateDto>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<long?, long>().ConvertUsing((src, dest) => src ?? dest);

        }
    }
}
