using MyExchange.BusinessLogic.Dtos.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IBankService
    {
        Task<BankDto> GetBank(int id);

        Task<BankDto> CreateBank(BankDto bankDto);

        Task DeleteBank(int id);
    }
}
