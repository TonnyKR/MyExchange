using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Dtos.PromoCode
{
    public class PromoCodeDto
    {
        [Required]
        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }
        [Required]
        public int CurrencyId { get; set; }
    }
}
