using AutoMapper;
using MyExchange.BusinessLogic.Dtos.Wallet;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Entities;
using MyExchange.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public WalletService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WalletDto> CreateDefaultWallet(UserDto userDto)
        {
            var walletDto = new WalletDto{
                WalletType = Data.Enums.WalletType.UAH,
                Balance = 0,
                TotalClosedMargin = 0,
                TotalCurrentCapital = 0,
                TotalCurrentMargin = 0,
                TotalEnrolment = 0,
                TotalWithdrawl = 0,
                UserId = userDto.Id
            };

            await CreateWallet(walletDto);
            return walletDto;
        }

        public async Task<WalletDto> CreateWallet(WalletDto walletDto)
        {
            var wallet = _mapper.Map<Wallet>(walletDto);
            _repository.Add(wallet);
            await _repository.SaveChangesAsync();

            var returnDto = _mapper.Map<WalletDto>(wallet);
            return returnDto;
        }        

        public async Task DeleteWallet(int id)
        {
            await _repository.Delete<Wallet>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<WalletDto>> GetAllUserWallets(int id)
        {
            var walletsList = await _repository.GetAll<Wallet>();           //Getting ALL wallets from db, not optimized
            walletsList = walletsList.Where(w => w.UserId == id).ToList();
            var walletsListDto = _mapper.Map<List<WalletDto>>(walletsList);
            return walletsListDto;
        }

        public async Task<IEnumerable<WalletDto>> GetAllWallets()
        {
            var walletsList = await _repository.GetAll<Wallet>();
            var walletsDtoList = _mapper.Map<List<WalletDto>>(walletsList);
            return walletsDtoList;
        }

        public async Task<WalletDto> GetWallet(int id)
        {
            var wallet = await _repository.GetById<Wallet>(id);
            var walletDto = _mapper.Map<WalletDto>(wallet);
            return walletDto;
        }

        public async Task UpdateWallet(int id, WalletUpdateDto walletDto)
        {
            var wallet = await _repository.GetById<Wallet>(id);
            wallet = _mapper.Map(walletDto, wallet);

            await _repository.SaveChangesAsync();
        }
    }
}
