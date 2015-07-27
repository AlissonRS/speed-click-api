using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedClick.API
{
    public static class AutoMapperFacade
    {
        public static T Map<T>(object obj)
        {
            return Mapper.Map<T>(obj);
        }

    }
}