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

namespace SpeedClick.Logic.Models
{
    public class User : BaseObject
    {

        private int _ranking = 0;
        private int _score = 0;

        public string Login { get; set; }
        [IgnoreDataMember]
        public string Password { get; set; }
        public int Status { get; set; }


        public User() : base() { }

        public User(int id) : base(id) { }

        public void CalculateRanking()
        {
            _ranking = BaseRepository<User>.getAll().OrderBy(u => u.GetScore()).ToList().FindIndex(us => us.ID == this.ID);
        }

        public void CalculateScore()
        {
            _score = BaseRepository<Score>.getAll(s => s.UserId == this.ID).Sum<Score>(sc => sc.Value);
        }

        public int GetRanking()
        {
            if (this._ranking == 0)
                this.CalculateRanking();
            return this._ranking;
        }

        public IEnumerable<Scene> getScenes()
        {
            return BaseRepository<Scene>.getAll(s => s.Creator == this.ID);
        }

        public int GetScore()
        {
            if (this._score == 0)
                this.CalculateScore();
            return this._score;
        }

        public IEnumerable<Score> GetScores()
        {
            return BaseRepository<Score>.getAll(s => s.UserId == this.ID);
        }

        public override ObjectTypes getObjectType()
        {
            return ObjectTypes.User;
        }

    }

}
