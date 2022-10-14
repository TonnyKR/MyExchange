using AutoMapper;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.Currency;
using MyExchange.Data.Interfaces;
using MyExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CurrencyService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            return currencyDto;        }

        public async Task UpdateCurrency(int id, CurrencyDto currencyDto)
        {
            var currency = await _repository.GetById<Currency>(id);
            _mapper.Map(currencyDto, currency);
            await _repository.SaveChangesAsync();
        }
    }
}
