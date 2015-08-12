using Alisson.Core;
using Alisson.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedClick.Logic.Models
{
    public class Score : BaseObject
    {

        public int UserId { get; set; }
        public int SceneId { get; set; }
        public int Value { get; set; }
        public int MaxCombo { get; set; }
        public int Errors { get; set; }
        public int Status { get; set; }

    }
}
