using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyExchange.Common.Dtos.BankCard
{
    public class BankCardDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "required")]
        [Range(100000000000, 9999999999999999999, ErrorMessage = "must be between 12 and 19 digits")]
        public long Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TerminalDate { get; set; }

        [Required]
        public int Cvv { get; set; }
        [Required]
        public int WalletId { get; set; }
        [Required]
        public int BankId { get; set; }
    }
}
