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
        public async Task<WalletPositionDto> CreateWalletPosition(WalletPositionDto walletPositionDto)
        {
            var position = _mapper.Map<WalletPosition>(walletPositionDto);

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
    }
}
