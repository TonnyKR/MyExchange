
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyExchange.Data.Entities
{
    public partial class User : IdentityUser
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
    }
}
