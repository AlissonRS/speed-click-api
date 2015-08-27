using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedClick.API.Models
{

    public class UserModelResponse
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public int Ranking { get; set; }
        public int Score { get; set; }
        public string AvatarUrl { get; set; }
    }


    public class UserModelPost
    {

        public string Login { get; set; }
        public string Password { get; set; }

    }
}