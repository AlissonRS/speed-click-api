using Alisson.Core.IoC;
using Alisson.Core.Repository;
using Alisson.Core.Types;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alisson.Core.Services.Commands.SubmitScore
{
    public class SubmitScoreCommandHandler : ICommandHandler<SubmitScoreCommandData>
    {

        public virtual SubmitScoreCommandData Handle(SubmitScoreCommandData command)
        {
            Score score = command.score;
            IEnumerable<Score> currentScores = BaseRepository<Score>.getAll().Where(s => s.SceneId == score.SceneId && s.PlayerId == score.PlayerId);
            Score currentScore;
            if (currentScores.Count() == 1)
            {
                currentScore = currentScores.First();
                if (currentScore.Points < score.Points)
                    currentScore.UpdateFrom(score);
                else
                    command.IsNewRecord = false;
            }
            else
                currentScore = score;

           BaseRepository<Score>.add(currentScore);
           Scene scene = BaseRepository<Scene>.getAll().First(s => s.ID == currentScore.SceneId);
            scene.PlayCount++;
            BaseRepository<Scene>.add(scene);
            command.score = currentScore;
            return command;
        }

    }
}
