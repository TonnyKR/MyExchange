using AutoMapper;
using Microsoft.Extensions.Logging;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.WalletBalance;
using MyExchange.Data.Interfaces;
using MyExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class WalletBalanceService : IWalletBalanceService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<WalletBalanceService> _logger;
        public WalletBalanceService(IRepository repository, IMapper mapper, ILogger<WalletBalanceService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<WalletBalanceDto>> GetAllWalletBalances()
        {
            var balancesList = await _repository.GetAll<WalletBalance>();
            var balancesDtoList = _mapper.Map<List<WalletBalanceDto>>(balancesList);
            return balancesDtoList;
        }

        public async Task<WalletBalanceDto> GetWalletBalance(int id)
        {
            var balance = await _repository.GetById<WalletBalance>(id);
            var balanceDto = _mapper.Map<WalletBalanceDto>(balance);
            return balanceDto;
        }

        public async Task RecieveUAH(int id, decimal UAH)
        {
            var balance = await _repository.GetById<WalletBalance>(id);
            await UpdateBallance(id, new WalletBalanceUpdateDto { UAH = balance.UAH + UAH });
        }

        public async Task RecieveUSD(int id, decimal USD)
        {
            var balance = await _repository.GetById<WalletBalance>(id);
            await UpdateBallance(id, new WalletBalanceUpdateDto { USD = balance.USD + USD });
        }

        public async Task TransmitUAH(int id, decimal UAH)
        {
            var balance = await _repository.GetById<WalletBalance>(id);
            if (balance.UAH < UAH)
            {
                throw new ArgumentException("Not enough USD");
            }
            else
                await UpdateBallance(id, new WalletBalanceUpdateDto { UAH = balance.UAH - UAH });
        }

        public async Task TransmitUSD(int id, decimal USD)
        {
            var balance = await _repository.GetById<WalletBalance>(id);
            if (balance.USD < USD)
            {
                throw new ArgumentException("Not enough USD");
            }
            else
            await UpdateBallance(id, new WalletBalanceUpdateDto { USD = balance.USD - USD });
        }

        public async Task UpdateBallance(int id, WalletBalanceUpdateDto walletBalanceUpdateDto)
        {
            var balance = await _repository.GetById<WalletBalance>(id);
            _logger.LogWarning($"Entity USD - {balance.USD}, UAH -{balance.UAH}");
            _mapper.Map(walletBalanceUpdateDto, balance);
            _logger.LogWarning($"DTO: USD - {walletBalanceUpdateDto.USD} , UAH - {walletBalanceUpdateDto.UAH}" +
                               $"Entity USD - {balance.USD}, UAH -{balance.UAH}");
            await _repository.SaveChangesAsync();
        }
    }
}
