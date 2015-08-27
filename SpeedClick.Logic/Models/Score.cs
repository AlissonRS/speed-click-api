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
            this.SceneId = score.SceneId;
            this.Speed = score.Speed;
            this.TurnCount = score.TurnCount;
            this.Status = score.Status;
        }

        protected override void beforeDeleting()
        {
            if (this.observers.Count == 0)
                this.Subscribe(this.GetPlayer());
            this.Notify();
        }

        private User GetPlayer()
        {
            return BaseRepository<User>.getByID(this.PlayerId);
        }

        protected override void beforeSaving()
        {
            if (this.observers.Count == 0)
                this.Subscribe(this.GetPlayer());
            this.Notify();
        }

        public int CalculateRanking()
        {
            return BaseRepository<Score>.getAll().Where(s => s.SceneId == this.SceneId).OrderByDescending(o => o.Points).ThenByDescending(a => a.Accuracy).ToList().FindIndex(i => i.PlayerId == this.PlayerId) + 1;
        }
    }
}
