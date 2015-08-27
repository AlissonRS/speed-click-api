using Alisson.Core.IoC;
using Alisson.Core.Repository;
using Alisson.Core.Services.Commands.SubmitScore;
using SpeedClick.API.Models;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpeedClick.API.Controllers
{
    public class ScoreController : ApiController
    {

        ICommandHandler<SubmitScoreCommandData> submitScore;

        public ScoreController(ICommandHandler<SubmitScoreCommandData> submitScore)
        {
            this.submitScore = submitScore;
        }

        public ResponseData<IEnumerable<ScoreModel>> Get()
        {
            ResponseData<IEnumerable<ScoreModel>> resp = new ResponseData<IEnumerable<ScoreModel>>();
            resp.Data = AutoMapperFacade.Map<IEnumerable<ScoreModel>>(BaseRepository<Score>.getAll());
            resp.Message = "";
            resp.Success = true;
            return resp;
        }
  
        public ResponseData<ScoreModelPostResponse> Post([FromBody]ScoreModel score)
        {
            ResponseData<ScoreModelPostResponse> resp = new ResponseData<ScoreModelPostResponse>();
            try
            {
                Score sco = AutoMapperFacade.Map<Score>(score);
                SubmitScoreCommandData data = new SubmitScoreCommandData(sco);
                submitScore.Handle(data);
                sco = data.score;
                ScoreModelPostResponse respScore = new ScoreModelPostResponse() { ID = sco.ID, IsNewRecord = data.IsNewRecord, Ranking = sco.CalculateRanking() };
                resp.Data = respScore;
                resp.Message = "Registro efetuado com sucesso!";
                resp.Success = true;
            }
            catch (Exception)
            {
                resp.Message = "Não foi possível submeter a pontuação!";
            }
            return resp;
        }
    }
}
