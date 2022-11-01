using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Entities
{
    public partial class PromoCode : BaseEntity
    {
        public decimal DiscountPercent { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public ICollection<WalletsPromoCodes> WalletsPromoCodes { get; set; }
    }
}
