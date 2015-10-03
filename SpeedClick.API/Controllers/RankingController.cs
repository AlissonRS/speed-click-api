using Alisson.Core.Repository;
using SpeedClick.API.Models;
using SpeedClick.Logic.Models;
using SpeedClick.Logic.Services.RankingCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpeedClick.API.Controllers
{
    [RoutePrefix("ranking")]
    public class RankingController : ApiController
    {

        private static readonly IRankingCalculator<IScoreRankedItem> scoreCalculator = new ScoreRankingCalculator();

        [Route("users/{quantity?}")]
        [HttpGet]
        public ResponseData<IEnumerable<UserModelResponse>> GetUsersOrderedByRanking(int quantity = 0)
        {
            ResponseData<IEnumerable<UserModelResponse>> resp = new ResponseData<IEnumerable<UserModelResponse>>();
            IEnumerable<UserModelResponse> users = AutoMapperFacade.Map<IEnumerable<UserModelResponse>>(BaseRepository<User>.getAll().OrderBy(o => scoreCalculator.RetrieveRanking(o)));
            resp.Data = (quantity == 0 ? users : users.Take(quantity));
            resp.Message = "";
            resp.Success = true;
            return resp;
        }

        [Route("scenes/{ID:int}/scores/{quantity:int?}")]
        [HttpGet]
        public ResponseData<IEnumerable<ScoreModel>> GetSceneScoresOrderedByRanking(int ID, int quantity = 0)
        {
            ResponseData<IEnumerable<ScoreModel>> resp = new ResponseData<IEnumerable<ScoreModel>>();
            IEnumerable<ScoreModel> scores = AutoMapperFacade.Map<IEnumerable<ScoreModel>>(BaseRepository<Score>.getAll().Where(s => s.SceneId == ID).OrderBy(o => scoreCalculator.RetrieveRanking(o)));
            resp.Data = (quantity == 0 ? scores : scores.Take(quantity));
            resp.Message = "";
            resp.Success = true;
            return resp;
        }
  

    }
}
