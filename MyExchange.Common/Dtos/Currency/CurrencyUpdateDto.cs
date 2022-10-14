using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.Currency
{
    public class CurrencyUpdateDto
    {
        public string? Name { get; set; } = null!;
        public string? ShortName { get; set; } = null!;
        public decimal? PriceUsd { get; set; }
        public string? MarketType { get; set; } = null!;
    }
}
