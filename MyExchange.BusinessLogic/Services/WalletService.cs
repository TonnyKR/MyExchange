using AutoMapper;
using MyExchange.BusinessLogic.Dtos.Wallet;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Entities;
using MyExchange.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository _repository;
        private readonly IWalletPositionService _walletPositionService;
        private readonly IMapper _mapper;
        public WalletService(IRepository repository, IMapper mapper,IWalletPositionService walletPositionService)
        {
            _repository = repository;
            _mapper = mapper;
            _walletPositionService = walletPositionService;
        }

        public async Task<WalletDto> CreateDefaultWallet(UserDto userDto)
        {
            var walletDto = new WalletDto{
                WalletType = Data.Enums.WalletType.USD,
                Balance = 0,
                TotalCurrentMargin = 0,
                TotalPositionsCost= 0,
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

        public async Task<IEnumerable<WalletDto>> GetAllUserWallets(string id)
        {
            var walletsList = await _repository.GetAll<Wallet>();           
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
            await UpdateTotalCurrentMargin(id);
            await UpdateTotalPositionCost(id);

            var wallet = await _repository.GetById<Wallet>(id);
            var walletDto = _mapper.Map<WalletDto>(wallet);
            
            return walletDto;
        }

        public async Task ReplenisBalance(int WalletId, int BankCardId, decimal amount)
        {
            var wallet = await _repository.GetById<Wallet>(WalletId);
            wallet.Balance += amount;
            wallet.TotalEnrolment += amount;

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateWallet(int id, WalletUpdateDto walletUpdateDto)
        {
            var wallet = await _repository.GetById<Wallet>(id);
            _mapper.Map(walletUpdateDto, wallet);

            await _repository.SaveChangesAsync();
        }

        public async Task WithdrawBalance(int WalletId, int BankCardId, decimal amount)
        {
            var wallet = await _repository.GetById<Wallet>(WalletId);

            if(wallet.Balance < amount)
            { throw new Exception("Not enough funds"); }
            else {
                wallet.Balance -= amount;
                wallet.TotalWithdrawl += amount;
            }
            

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateTotalCurrentMargin(int walletId)
        {
            var positionList = await _walletPositionService.GetWalletPositions(walletId);
            decimal marginSum = 0;        
            if (positionList.Count() != 0)
            {
                foreach (var position in positionList)
                {
                    marginSum += (decimal)position.CurrentMargin;
                }
                var totalCurrentMargin = marginSum / positionList.Count();
                await UpdateWallet(walletId, new WalletUpdateDto { TotalCurrentMargin = totalCurrentMargin });
            }
        }

        public async Task UpdateTotalPositionCost(int walletId)
        {
            var positionList = await _walletPositionService.GetWalletPositions(walletId);
            decimal totalCost = 0;
            if(positionList.Count() != 0)
            {
                foreach (var position in positionList)
                {
                    totalCost += (decimal)(position.Quantity * (await _repository.GetById<Currency>(position.CurrencyId)).PriceUsd);
                }
                await UpdateWallet(walletId, new WalletUpdateDto { TotalPositionsCost = totalCost });
            }
            
        }
    }
}
