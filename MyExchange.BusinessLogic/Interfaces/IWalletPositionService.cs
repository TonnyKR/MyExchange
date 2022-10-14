using MyExchange.Common.Dtos.WalletPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IWalletPositionService
    {
        Task<WalletPositionDto> GetWalletPosition(int id);
        Task<IEnumerable<WalletPositionDto>> GetAllWalletPositions();

        Task<WalletPositionDto> CreateWalletPosition(WalletPositionDto walletPositionDto);

        Task UpdateWalletPosition(int id, WalletPositionUpdateDto walletPositionUpdateDto);

        Task DeleteWalletPosition(int id);
    }
}
