using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Dtos.Account
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool HasError { get; set; }
        public string Error{ get; set; }
    }
}
