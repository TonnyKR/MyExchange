using MyExchange.Common.Dtos.WalletPosition;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IWalletPositionService
    {
        Task AddToWalletPosition(WalletPositionDto walletPositionDto);
        Task SellWalletPosition(WalletPositionDto walletPositionDto);
        Task UpdateCurrentMargin(int currencyId);
        Task<WalletPositionDto> GetWalletPosition(int id);
        Task<decimal> CalculateProfit(WalletPositionDto walletPosition);
        Task<IEnumerable<WalletPositionDto>> GetAllWalletPositions();
        Task<IEnumerable<WalletPositionDto>> GetWalletPositions(int walletId);

        Task<WalletPositionDto> CreateWalletPosition(WalletPositionDto walletPositionDto);

        Task UpdateWalletPosition(int id, WalletPositionUpdateDto walletPositionUpdateDto);

        Task DeleteWalletPosition(int id);
    }
}
