using Alisson.Core;
using Alisson.Core.Repository;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Services.RankingCalculator
{
    public class ScoreRankingCalculator: IRankingCalculator<IScoreRankedItem>
    {

        public int RetrieveRanking(IScoreRankedItem ranked)
        {
            if (ranked.GetRankingByScore() == 0)
                this.Calculate(ranked);
            return ranked.GetRankingByScore();
        }

        public IRankingCalculator<IScoreRankedItem> Calculate(IScoreRankedItem ranked)
        {
            List<IScoreRankedItem> range = ranked.GetOrderedRange();
            int currentRanking = ranked.GetRankingByScore();
            int newRanking = range.FindIndex(us => us.Equals(ranked)) + 1;
            IScoreRankedItem currentRankingOwner = range.Where(o => o.GetRankingByScore() == newRanking).FirstOrDefault();
            if (currentRanking == 0 && currentRankingOwner != null && !currentRankingOwner.Equals(ranked))
                UpdateAffectedItems(range.Where(a => a.GetRankingByScore() >= newRanking).ToList());
            else if (currentRanking > newRanking) // If my new ranking is better (which means its lower)
                // Get the item who currently holds our new ranking, up to the item who is going to get our current ranking...
                UpdateAffectedItems(range.Where(a => a.GetRankingByScore() >= newRanking && a.GetRankingByScore() < currentRanking).ToList());
            ranked.SetRankingByScore(newRanking);
            return this;
        }

        public IRankingCalculator<IScoreRankedItem> Update(IScoreRankedItem ranked)
        {
            List<IScoreRankedItem> range = ranked.GetOrderedRange();
            int currentRanking = ranked.GetRankingByScore();
            int newRanking = range.FindIndex(us => us.Equals(ranked)) + 1;
            if (currentRanking == 0)
                UpdateAffectedItems(range.Where(a => a.GetRankingByScore() >= newRanking).ToList());
            else if (currentRanking > newRanking) // If my new ranking is better (which means its lower)
                // Get the item who currently holds our new ranking, up to the item who is going to get our current ranking...
                UpdateAffectedItems(range.Where(a => a.GetRankingByScore() >= newRanking && a.GetRankingByScore() < currentRanking).ToList());
            ranked.SetRankingByScore(newRanking);
            return this;
        }

        private void UpdateAffectedItems(List<IScoreRankedItem> affectedItems)
        {
            foreach (IScoreRankedItem item in affectedItems)
                item.SetRankingByScore(item.GetRankingByScore() + 1);
        }

    }
}
