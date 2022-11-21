using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.BankCard
{
    public class BankCardUpdateDto
    {
        [CreditCard]
        public long Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime TerminalDate { get; set; }
        [MaxLength(3)]
        [MinLength(3)]
        public int Cvv { get; set; }
    }
}
