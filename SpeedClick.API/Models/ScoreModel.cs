using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedClick.API.Models
{
    public class ScoreModel
    {
        public int UserId { get; set; }
        public int SceneId { get; set; }
        public int Value { get; set; }
        public int MaxCombo { get; set; }
        public int Errors { get; set; }
    }
}
