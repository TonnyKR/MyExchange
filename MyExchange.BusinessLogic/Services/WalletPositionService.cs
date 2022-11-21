using AutoMapper;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.WalletPosition;
using MyExchange.Data.Interfaces;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyExchange.BusinessLogic.Services
{
    public class WalletPositionService : IWalletPositionService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public WalletPositionService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddToWalletPosition(WalletPositionDto walletPositionDto)
        {
            var positionDto = (await GetAllWalletPositions()).FirstOrDefault(p => p.CurrencyId == walletPositionDto.CurrencyId && p.WalletId == walletPositionDto.WalletId);
            var currency = await _repository.GetById<Currency>(walletPositionDto.CurrencyId);

            positionDto.EntryPrice = (currency.PriceUsd * walletPositionDto.Quantity + positionDto.EntryPrice * positionDto.Quantity) / 
                                                        (walletPositionDto.Quantity + positionDto.Quantity);       //Average price as new EntryPrice
            positionDto.Quantity += walletPositionDto.Quantity;
            positionDto.CurrentMargin = 100 * (await CalculateProfit(positionDto)) / (positionDto.Quantity * currency.PriceUsd);

            await UpdateWalletPosition(positionDto.Id, _mapper.Map<WalletPositionUpdateDto>(positionDto));

        }

        public async Task SellWalletPosition(WalletPositionDto walletPositionDto)
        {
            var position = GetAllWalletPositions().Result.FirstOrDefault(p => p.CurrencyId == walletPositionDto.CurrencyId && p.WalletId == walletPositionDto.WalletId);
            if (position.Quantity >= walletPositionDto.Quantity)
            {
                walletPositionDto.EntryPrice = position.EntryPrice;
                position.Quantity -= walletPositionDto.Quantity;
            }
            else
            {
                throw new Exception("Not enough stock balance");
            }
            if (position.Quantity == 0)
            {
                position.CurrentMargin = 0;
                position.EntryPrice = 0;
            }
            var wallet = await _repository.GetById<Wallet>(position.WalletId);
            wallet.Balance += walletPositionDto.Quantity * (_repository.GetById<Currency>(walletPositionDto.CurrencyId).Result.PriceUsd);

            await UpdateWalletPosition(position.Id, _mapper.Map<WalletPositionUpdateDto>(position));

        }
        public async Task UpdateCurrentMargin(int currencyId)
        {
            var walletPositionsList = await GetAllWalletPositions();
            walletPositionsList = walletPositionsList.Where(c => c.CurrencyId == currencyId);
            foreach (var position in walletPositionsList)
            {
                position.CurrentMargin = 100 * (await CalculateProfit(position))/(position.Quantity * _repository.GetById<Currency>(currencyId).Result.PriceUsd);
                await UpdateWalletPosition(position.Id, _mapper.Map<WalletPositionUpdateDto>(position));
            }            
        }

        public async Task<decimal> CalculateProfit(WalletPositionDto walletPosition)
        {
            var currency = await _repository.GetById<Currency>(walletPosition.CurrencyId);
            return (decimal)((currency.PriceUsd - walletPosition.EntryPrice) * walletPosition.Quantity);
        }

        public async Task<WalletPositionDto> CreateWalletPosition(WalletPositionDto walletPositionDto)
        {
            var position = _mapper.Map<WalletPosition>(walletPositionDto);
            position.EntryPrice = _repository.GetById<Currency>(position.CurrencyId).Result.PriceUsd;
            position.CurrentMargin = 0;

            _repository.Add(position);
            await _repository.SaveChangesAsync();

            var _walletPositionDto = _mapper.Map<WalletPositionDto>(position);

            return _walletPositionDto;
        }

        public async Task DeleteWalletPosition(int id)
        {
            await _repository.Delete<WalletPosition>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<WalletPositionDto>> GetAllWalletPositions()
        {
            var positionList = await _repository.GetAll<WalletPosition>();
            var positionDtoList = _mapper.Map<List<WalletPositionDto>>(positionList);
            return positionDtoList;
        }

        public async Task<WalletPositionDto> GetWalletPosition(int id)
        {
            var position = await _repository.GetById<WalletPosition>(id);
            var positionDto = _mapper.Map<WalletPositionDto>(position);
            return positionDto;
        }

        public async Task UpdateWalletPosition(int id, WalletPositionUpdateDto walletPositionDto)
        {
            var position = await _repository.GetById<WalletPosition>(id);
            _mapper.Map(walletPositionDto, position);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<WalletPositionDto>> GetWalletPositions(int walletId)
        {
           return (await GetAllWalletPositions()).Where(p => p.WalletId == walletId);
        }
    }
}
