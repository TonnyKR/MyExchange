using System;
using System.Collections.Generic;

namespace MyExchange.Data.Entities
{
    public partial class User : BaseEntity
    {

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long? PhoneNumber { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
    }
}
