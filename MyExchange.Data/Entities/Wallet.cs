using MyExchange.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Entities
{
    public partial class Wallet : BaseEntity
    {
        public WalletType WalletType { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalCurrentCapital { get; set; }
        public decimal TotalEnrolment { get; set; }
        public decimal TotalWithdrawl { get; set; }
        public decimal TotalCurrentMargin { get; set; }
        public decimal TotalClosedMargin { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<WalletPosition> WalletPositions { get; set; }
        public ICollection<WalletsPromoCodes> WalletsPromoCodes { get; set;}
        public ICollection<BankCard> BankCards { get; set; }
    }
}
