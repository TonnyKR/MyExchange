using AutoMapper;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.Currency;
using MyExchange.Data.Interfaces;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExchange.Common.Dtos.WalletPosition;

namespace MyExchange.BusinessLogic.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWalletPositionService _walletPositionService;
        public CurrencyService(IRepository repository, IMapper mapper, IWalletPositionService walletPositionService)
        {
            _repository = repository;
            _mapper = mapper;
            _walletPositionService = walletPositionService;
        }
        public async Task<CurrencyDto> CreateCurrency(CurrencyDto currencyDto)
        {
            var currency = _mapper.Map<Currency>(currencyDto);
            
            _repository.Add(currency);
            await _repository.SaveChangesAsync();

            var _currencyDto = _mapper.Map<CurrencyDto>(currency);

            return _currencyDto;
        }

        public async Task DeleteCurrency(int id)
        {
            await _repository.Delete<Currency>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllCurrencies()
        {
            var currencyList = await _repository.GetAll<Currency>();
            var currencyDtoList = _mapper.Map<List<CurrencyDto>>(currencyList);
            return currencyDtoList;
        }

        public async Task<CurrencyDto> GetCurrency(int id)
        {
            var currency = await _repository.GetById<Currency>(id);
            var currencyDto = _mapper.Map<CurrencyDto>(currency);
            return currencyDto;
        }

        public async Task UpdateCurrency(int id, CurrencyUpdateDto currencyUpdateDto)
        {
            var currency = await _repository.GetById<Currency>(id);
            
            if (currencyUpdateDto.PriceUsd != null && currencyUpdateDto.PriceUsd != currency.PriceUsd)
            {
                _mapper.Map(currencyUpdateDto, currency);
                await _repository.SaveChangesAsync();
                await _walletPositionService.UpdateCurrentMargin(id);
            }
            else
            {
                _mapper.Map(currencyUpdateDto, currency);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
