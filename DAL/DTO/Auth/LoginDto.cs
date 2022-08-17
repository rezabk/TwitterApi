using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Auth
{
    public class LoginDto
    {
        public string UserNameOrPassword { get; set; }

        public string Password { get; set; }
    }
}
