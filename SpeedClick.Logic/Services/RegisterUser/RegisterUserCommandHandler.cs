using Alisson.Core.IoC;
using Alisson.Core.Repository;
using Alisson.Core.Types;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alisson.Core.Services.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommandData>
    {

        public RegisterUserCommandHandler()
        {
            
        }

        public virtual RegisterUserCommandData Handle(RegisterUserCommandData command)
        {
            BaseRepository<User>.add(command.user);
            UserIp ip = new UserIp() { Ip = command.IP, UserId = command.user.ID };
            BaseRepository<UserIp>.add(ip);
            return command;
        }

    }
}
