using MyExchange.Common.Dtos.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyDto> GetCurrency(int id);
        Task<IEnumerable<CurrencyDto>> GetAllCurrencies();
        Task<CurrencyDto> CreateCurrency(CurrencyDto currencyDto);

        Task UpdateCurrency(int id, CurrencyUpdateDto currencyUpdateDto);

        Task DeleteCurrency(int id);
    }
}
