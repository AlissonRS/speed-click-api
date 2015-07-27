using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alisson.Core.Services.Commands.RegisterUser
{
    public class RegisterUserCommandData
    {
        public User user;
        public string IP;

        public RegisterUserCommandData(string login, string password, string IP)
        {
            this.user = new User() { Login = login, Password = password, Status = 0 };
            this.IP = IP;
        }
    }
}
