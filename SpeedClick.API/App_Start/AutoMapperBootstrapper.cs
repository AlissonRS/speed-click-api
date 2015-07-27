using SpeedClick.API.Models;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedClick.API
{
    public static class AutoMapperBootstrapper
    {

        public static void Configure()
        {
            AutoMapper.Mapper.CreateMap<User, UserModelPost>();
            AutoMapper.Mapper.CreateMap<User, UserModelResponse>();
        }

    }
}