using AutoMapper;
using MyExchange.BusinessLogic.Dtos.Bank;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<Bank, BankDto>();
            CreateMap<BankDto, Bank>();
        }
    }
}
