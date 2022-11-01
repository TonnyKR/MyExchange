using AutoMapper;
using MyExchange.BusinessLogic.Dtos.PromoCode;
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
    public class PromoCodeService : IPromoCode
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public PromoCodeService(IRepository repository, IMapper mapper, IWalletService walletService)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PromoCodeDto> CreatePromoCode(PromoCodeDto promoCodeDto)
        {
            var promo = _mapper.Map<PromoCode>(promoCodeDto);
            _repository.Add(promo);
            await _repository.SaveChangesAsync();

            var returnDto = _mapper.Map<PromoCodeDto>(promo);
            return returnDto;
        }

        public async Task DeletePromoCode(int id)
        {
            await _repository.Delete<PromoCode>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PromoCodeDto>> GetAllPromoCodes()
        {
            var promoCodeList = await _repository.GetAll<PromoCode>();
            var promoCodeDtoList = _mapper.Map<List<PromoCodeDto>>(promoCodeList);
            return promoCodeDtoList;
        }

        public async Task<PromoCodeDto> GetPromoCode(int id)
        {
            var promoCode = await _repository.GetById<PromoCode>(id);
            var promoCodeDto = _mapper.Map<PromoCodeDto>(promoCode);
            return promoCodeDto;
        }

        public async Task UpdatePromoCode(int id, PromoCodeDto promoCodeDto)
        {
            var promoCode = await _repository.GetById<PromoCode>(id);
            promoCode = _mapper.Map(promoCodeDto, promoCode);

            await _repository.SaveChangesAsync();
        }
    }
}
