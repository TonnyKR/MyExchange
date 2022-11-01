using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Dtos.PromoCode
{
    public class PromoCodeDto
    {
        public decimal DiscountPercent { get; set; }
        public int CurrencyId { get; set; }
    }
}
