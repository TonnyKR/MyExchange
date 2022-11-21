using MyExchange.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Dtos.Wallet
{
    public class WalletDto
    {
        public int Id { get; set; }
        [Required]
        public WalletType WalletType { get; set; }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalEnrolment { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalWithdrawl { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalCurrentMargin { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalPositionsCost { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
