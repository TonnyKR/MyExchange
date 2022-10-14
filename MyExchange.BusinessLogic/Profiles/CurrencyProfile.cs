using AutoMapper;
using MyExchange.Common.Dtos.Currency;
using MyExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();
            CreateMap<CurrencyUpdateDto, Currency>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
        }
    }
}
