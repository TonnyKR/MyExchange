using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.WalletPosition
{
    public class WalletPositionDto
    {
        public int Id { get; set; }
        [Required]       
        public decimal Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal? EntryPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal? CurrentMargin { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public int WalletId { get; set; }
        [Required]
        public int CurrencyId { get; set; }
    }
}
