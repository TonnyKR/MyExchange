using MyExchange.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.User
{
    public class UserDto
    {
        public string? Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
