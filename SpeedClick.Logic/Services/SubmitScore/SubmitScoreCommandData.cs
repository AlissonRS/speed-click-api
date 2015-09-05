using Alisson.Core.Repository;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alisson.Core.Services.Commands.SubmitScore
{
    public class SubmitScoreCommandData
    {
        public Score score;
        public User user;
        public bool IsNewRecord = true;

        public SubmitScoreCommandData(Score score)
        {
            this.score = score;
            this.user = BaseRepository<User>.getByID(score.PlayerId);
        }
    }
}
