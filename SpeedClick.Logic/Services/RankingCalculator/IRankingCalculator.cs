using Alisson.Core;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Services.RankingCalculator
{
    public interface IRankingCalculator<T>
    {
        IRankingCalculator<T> Calculate(T ranked);

        int RetrieveRanking(T ranked);
    }
}
