using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Entities
{
    public partial class Bank : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BankCard> BankCards { get; set; }
    }
}
