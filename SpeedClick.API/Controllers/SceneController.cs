using Alisson.Core.Repository;
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
    public class SceneController : ApiController
    {

        public ResponseData<IEnumerable<SceneModel>> Get()
        {
            ResponseData<IEnumerable<SceneModel>> resp = new ResponseData<IEnumerable<SceneModel>>();
            resp.Data = AutoMapperFacade.Map<IEnumerable<SceneModel>>(BaseRepository<Scene>.getAll());
            resp.Message = "";
            resp.Success = true;
            return resp;
        }
  
    }
}
