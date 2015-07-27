using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedClick.API.Models
{
    public class ResponseData<T>
    {

        public T Data;
        public string Message;
        public bool Success = false;

    }
}