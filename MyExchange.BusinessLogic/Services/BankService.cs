using AutoMapper;
using MyExchange.BusinessLogic.Dtos.Bank;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Data.Entities;
using MyExchange.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class BankService : IBankService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public BankService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BankDto> CreateBank(BankDto bankDto)
        {
            var bank = _mapper.Map<Bank>(bankDto);
            _repository.Add(bank);
            await _repository.SaveChangesAsync();

            var returnDto = _mapper.Map<BankDto>(bank);
            return returnDto;
        }

        public async Task DeleteBank(int id)
        {
            await _repository.Delete<Bank>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BankDto>> GetAllBanks()
        {
            var banks = await _repository.GetAll<Bank>();
            var banksDto = _mapper.Map<IEnumerable<BankDto>>(banks);
            return banksDto;
        }

        public async Task<BankDto> GetBank(int id)
        {
            var bank = await _repository.GetById<Bank>(id);
            var bankDto = _mapper.Map<BankDto>(bank);
            return bankDto;
        }
    }
}
