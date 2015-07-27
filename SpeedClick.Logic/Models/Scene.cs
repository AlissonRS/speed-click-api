using Alisson.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Models
{
    public class Scene: BaseObject
    {

        public String Name { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Creator { get; set; }

    }
}
