using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Entities
{
    public partial class WalletsPromoCodes : BaseEntity
    {
        public int PromoCodeId { get; set; }
        public PromoCode PromoCode { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
