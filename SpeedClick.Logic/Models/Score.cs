using Alisson.Core;
using Alisson.Core.Repository;
using SpeedClick.Logic.Services.RankingCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedClick.Logic.Models
{
    public class Score : BaseObject, IScoreRankedItem
    {
        private int ranking = 0;
        private float accuracy = 0;

        public int MaxCombo { get; set; }
        public int MissCount { get; set; }
        public int Platform { get; set; }
        public int PlayerId { get; set; }
        public int Points { get; set; }
        public int SceneId { get; set; }
        public float Speed { get; set; }
        public int TurnCount { get; set; }

        public void UpdateFrom(Score score)
        {
            this.Points = score.Points;
            this.MaxCombo = score.MaxCombo;
            this.Platform = score.Platform;
            this.PlayerId = score.PlayerId;
            this.Points = score.Points;
            this.SceneId = score.SceneId;
            this.Speed = score.Speed;
            this.TurnCount = score.TurnCount;
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

        private void CalculateAccuracy()
        {
            this.accuracy = (1f - (Convert.ToSingle(this.MissCount) / Convert.ToSingle(this.TurnCount))) * 100f;
        }

        public float GetAccuracy()
        {
            if (this.accuracy == 0)
                this.CalculateAccuracy();
            return this.accuracy;
        }

        public int GetRankingByScore()
        {
            return this.ranking;
        }

        public int GetScore()
        {
            return this.Points;
        }

        public void SetRankingByScore(int ranking)
        {
            this.ranking = ranking;
        }


        public List<IScoreRankedItem> GetOrderedRange()
        {
            return BaseRepository<Score>.getAll().Where(s => s.SceneId == this.SceneId)
                .OrderByDescending(s => s.Points)
                .ThenByDescending(s => s.accuracy)
                .ThenBy(s => s.UpdatedAt).ToList().ToList<IScoreRankedItem>();
        }
    }
}
