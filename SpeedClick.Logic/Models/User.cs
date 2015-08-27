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

        private int _score = 0;

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

        public int GetRanking()
        {
            return BaseRepository<User>.getAll().OrderByDescending(u => u.GetScore()).ToList().FindIndex(us => us.ID == this.ID) + 1;
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

        public override void Update(ISubject sub)
        {
            this.CalculateScore();
        }

    }

}
