using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyExchange.BusinessLogic.Dtos.Bank
{
    public class BankDto
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
