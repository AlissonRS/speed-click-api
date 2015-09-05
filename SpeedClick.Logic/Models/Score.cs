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
        private int _ranking = 0;
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
            //this.CreatedAt = DateTime.UtcNow;
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
            base.beforeSaving();
            if (this.observers.Count == 0)
                this.Subscribe(this.GetPlayer());
            this.Notify();
        }

        public void CalculateRanking()
        {
            this._ranking = BaseRepository<Score>.getAll().Where(s => s.SceneId == this.SceneId)
                .OrderByDescending(s => s.Points)
                .ThenByDescending(s => s.Accuracy)
                .ThenBy(s => s.UpdatedAt)
                .ToList().FindIndex(s => s.PlayerId == this.PlayerId) + 1;
        }

        public int GetRanking()
        {
            if (this._ranking == 0)
                this.CalculateRanking();
            return this._ranking;
        }

    }
}
