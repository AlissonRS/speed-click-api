﻿using Alisson.Core.IoC;
using Alisson.Core.Repository;
using Alisson.Core.Types;
using SpeedClick.Logic.Models;
using SpeedClick.Logic.Services.RankingCalculator;
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

            if (command.IsNewRecord)
            {
                BaseRepository<Score>.add(currentScore);
                command.user.CalculateScore();
                (new ScoreRankingCalculator()).Calculate(command.user).Calculate(currentScore);
            }
            Scene scene = BaseRepository<Scene>.getAll().First(s => s.ID == currentScore.SceneId);
            scene.PlayCount++;
            BaseRepository<Scene>.add(scene);
            command.score = currentScore;
            return command;
        }

    }
}
