using MyExchange.BusinessLogic.Dtos.PromoCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IPromoCode
    {
        Task<PromoCodeDto> GetPromoCode(int id);
        Task<IEnumerable<PromoCodeDto>> GetAllPromoCodes();
        Task<PromoCodeDto> CreatePromoCode(PromoCodeDto promoCodeDto);

        Task UpdatePromoCode(int id, PromoCodeDto promoCodeDto);

        Task DeletePromoCode(int id);
    }
}
