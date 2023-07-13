using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UserRegisterDto : IDto
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; }
        public int UnitId { get; set; }
    }
}
