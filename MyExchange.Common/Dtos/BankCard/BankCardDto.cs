using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.BankCard
{
    public class BankCardDto
    {
        public int Id { get; set; }
        public long Number { get; set; }
        public DateTime TerminalDate { get; set; }
        public int Cvv { get; set; }
        public long UserId { get; set; }
    }
}
