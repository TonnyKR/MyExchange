using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.Currency
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [MaxLength(6)]
        [DataType(DataType.Text)]
        public string ShortName { get; set; }
        [Range(0, 10000000)]
        [DataType(DataType.Currency)]
        public decimal PriceUsd { get; set; }
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public string MarketType { get; set; }
    }
}
