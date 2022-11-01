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
        Task<IEnumerable<WalletDto>> GetAllUserWallets(int id);

        Task<WalletDto> CreateWallet(WalletDto walletDto);
        Task<WalletDto> CreateDefaultWallet(UserDto userDto);

        Task UpdateWallet(int id, WalletUpdateDto walletDto);

        Task DeleteWallet(int id);
    }
}
