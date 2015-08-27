using Alisson.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpeedClick.API.Controllers
{
    public class SessionController : ApiController
    {
 
        [Route("api/session/clearall")]
        [HttpGet]
        public string ClearAll()
        {
            try
            {
                ConcreteList.clearAll();
                return "Listas apagadas com sucesso!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
