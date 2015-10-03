using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Services.RankingCalculator
{

    public interface IRankedItem
    {

    }

    public interface IScoreRankedItem : IRankedItem
    {

        List<IScoreRankedItem> GetOrderedRange();
        int GetRankingByScore();
        int GetScore();
        void SetRankingByScore(int ranking);

    }
}
