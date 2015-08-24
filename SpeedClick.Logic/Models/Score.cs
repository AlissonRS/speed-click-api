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
        public float Accuracy { get; set; }
        public int MaxCombo { get; set; }
        public int MissCount { get; set; }
        public int Platform { get; set; }
        public int PlayerId { get; set; }
        public int Points { get; set; }
        public int Ranking { get; set; }
        public int SceneId { get; set; }
        public float Speed { get; set; }
        public int TurnCount { get; set; }
        public int Status { get; set; }

        public void UpdateFrom(Score score)
        {
            this.Points = score.Points;
            this.Accuracy = score.Accuracy;
            this.MaxCombo = score.MaxCombo;
            this.Platform = score.Platform;
            this.PlayerId = score.PlayerId;
            this.Points = score.Points;
            this.Ranking = score.Ranking;
            this.SceneId = score.SceneId;
            this.Speed = score.Speed;
            this.TurnCount = score.TurnCount;
            this.Status = score.Status;
        }
    }
}
