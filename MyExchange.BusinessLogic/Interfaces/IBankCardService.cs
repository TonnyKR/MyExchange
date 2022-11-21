using MyExchange.Common.Dtos.BankCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IBankCardService
    {
        Task<BankCardDto> GetBankCard(int id);
        Task<IEnumerable<BankCardDto>> GetAllBankCards();

        Task<BankCardDto> CreateBankCard(BankCardDto bankCardDto);

        Task DeleteBankCard(int id);
    }
}
