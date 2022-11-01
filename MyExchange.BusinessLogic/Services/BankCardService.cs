using AutoMapper;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.BankCard;
using MyExchange.Data.Entities;
using MyExchange.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class BankCardService : IBankCardService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public BankCardService(IRepository repository, IMapper mapper)
        {
               _repository = repository;
               _mapper = mapper;
        }
        public async Task<BankCardDto> CreateBankCard(BankCardDto bankCardDto)
        {
            var card = _mapper.Map<BankCard>(bankCardDto);
            _repository.Add(card);
            await _repository.SaveChangesAsync();

            var returnDto = _mapper.Map<BankCardDto>(card);
            return returnDto;
        }

        public async Task DeleteBankCard(int id)
        {
            await _repository.Delete<BankCard>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<BankCardDto> GetBankCard(int id)
        {
            var card = await _repository.GetById<BankCard>(id);
            var cardDto = _mapper.Map<BankCardDto>(card);
            return cardDto;
        }
    }
}
