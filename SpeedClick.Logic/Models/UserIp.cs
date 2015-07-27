using Alisson.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Models
{
    public class UserIp: BaseObject
    {

        public int UserId { get; set; }
        public string Ip { get; set; }

        public UserIp() : base() { }

        public UserIp(int id) : base(id) { }

    }
}
