using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.BankCard
{
    public class BankCardUpdateDto
    {
        /// <summary>
        /// Not really needed
        /// </summary>
        public long Number { get; set; }
        public DateTime TerminalDate { get; set; }
        public int Cvv { get; set; }
    }
}
