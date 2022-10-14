using MyExchange.Common.Dtos.WalletBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IWalletBalanceService
    {
        Task<WalletBalanceDto> GetWalletBalance(int id);
        Task<IEnumerable<WalletBalanceDto>> GetAllWalletBalances();
        Task UpdateBallance(int id, WalletBalanceUpdateDto walletBalanceDto);
        Task RecieveUAH(int id, decimal UAH);
        Task TransmitUAH(int id, decimal UAH);

        Task RecieveUSD(int id, decimal USD);
        Task TransmitUSD(int id, decimal USD);

    }
}
