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
        public bool IsNewRecord = true;

        public SubmitScoreCommandData(Score score)
        {
            this.score = score;
        }
    }
}
