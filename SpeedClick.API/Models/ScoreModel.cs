using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedClick.API.Models
{
    public class ScoreModel
    {
        public int ID { get; set; }
        public float Accuracy { get; set; }
        public int MaxCombo { get; set; }
        public int MissCount { get; set; }
        public int Platform { get; set; }
        public int Points { get; set; }
        public int Ranking { get; set; }
        public int SceneId { get; set; }
        public float Speed { get; set; }
        public int TurnCount { get; set; }
        public int PlayerId { get; set; }
        public UserModelResponse Player { get; set; }
    }

    public class ScoreModelPostResponse
    {
        public int ID { get; set; }
        public bool IsNewRecord { get; set; }
        public int Ranking { get; set; }
    }

}
