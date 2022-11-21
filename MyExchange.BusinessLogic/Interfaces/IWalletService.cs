using MyExchange.BusinessLogic.Dtos.Wallet;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IWalletService
    {
        Task<WalletDto> GetWallet(int id);
        Task<IEnumerable<WalletDto>> GetAllWallets();
        Task<IEnumerable<WalletDto>> GetAllUserWallets(string id);

        Task<WalletDto> CreateWallet(WalletDto walletDto);
        Task<WalletDto> CreateDefaultWallet(UserDto userDto);
        Task ReplenisBalance(int WalletId, int BankCardId, decimal amount);
        Task WithdrawBalance(int WalletId, int BankCardId, decimal amount);

        Task UpdateWallet(int id, WalletUpdateDto walletDto);

        Task DeleteWallet(int id);
    }
}
