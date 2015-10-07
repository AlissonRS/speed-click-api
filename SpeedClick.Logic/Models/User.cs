using Alisson.Core;
using Alisson.Core.Encryption;
using Alisson.Core.Repository;
using Alisson.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using SpeedClick.Logic.Services.RankingCalculator;

namespace SpeedClick.Logic.Models
{
    public class User : BaseObject, IScoreRankedItem
    {

        private int _score = 0;
        private int ranking;

        public string Login { get; set; }
        [IgnoreDataMember]
        public string Password { get; set; }
        public int Status { get; set; }
        public string AvatarUrl { get; set; }


        public User() : base() { }

        public User(int id) : base(id) { }

        public void CalculateScore()
        {
            _score = BaseRepository<Score>.getAll(s => s.PlayerId == this.ID).Sum<Score>(sc => sc.Points);
        }

        public int GetRankingByScore()
        {
            return this.ranking;
        }

        public IEnumerable<Scene> getScenes()
        {
            return BaseRepository<Scene>.getAll(s => s.CreatorID == this.ID);
        }

        public int GetScore()
        {
            if (this._score == 0)
                this.CalculateScore();
            return this._score;
        }

        public IEnumerable<Score> GetScores()
        {
            return BaseRepository<Score>.getAll(s => s.PlayerId == this.ID);
        }

        public override ObjectTypes getObjectType()
        {
            return ObjectTypes.User;
        }

        public void SetRankingByScore(int ranking)
        {
            this.ranking = ranking;
        }

        public override void Update(ISubject sub)
        {
            this.CalculateScore();
        }


        public List<IScoreRankedItem> GetOrderedRange()
        {
            List<IScoreRankedItem> r = new List<IScoreRankedItem>();
            IOrderedEnumerable<User> users = BaseRepository<User>.getAll().OrderByDescending(u => u.GetScore()).ThenBy(u => u.CreatedAt);
            foreach (User user in users)
                r.Add(user);
            return r;
        }
    }

}
