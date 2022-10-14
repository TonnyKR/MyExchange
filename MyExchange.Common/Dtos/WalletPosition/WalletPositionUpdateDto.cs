using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.WalletPosition
{
    public class WalletPositionUpdateDto
    {
        public decimal? Quantity { get; set; }
        public decimal? EntryPrice { get; set; }
        public decimal? ClosePrice { get; set; }
        public decimal CurrentMargin { get; set; }
        public decimal? ClosedMargin { get; set; }
    }
}
