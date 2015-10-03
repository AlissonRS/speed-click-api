using Alisson.Core.Repository;
using SpeedClick.API.Models;
using SpeedClick.Logic.Models;
using SpeedClick.Logic.Services.RankingCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedClick.API
{
    public static class AutoMapperBootstrapper
    {

        public static void Configure(IRankingCalculator<IScoreRankedItem> calculator)
        {
            AutoMapper.Mapper.CreateMap<Scene, SceneModel>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(
                    src => BaseRepository<User>.getByID(src.CreatorID)))
                .ForMember(dest => dest.Scores, opt => opt.MapFrom(src => src.GetScores()));

            AutoMapper.Mapper.CreateMap<Score, ScoreModel>()
                    .ForMember(dest => dest.Player, opt => opt.MapFrom(src => BaseRepository<User>.getByID(src.PlayerId)))
                    .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => calculator.RetrieveRanking(src)))
                    .ForMember(dest => dest.Accuracy, opt => opt.MapFrom(src => src.GetAccuracy())
                    );

            AutoMapper.Mapper.CreateMap<ScoreModel, Score>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            AutoMapper.Mapper.CreateMap<User, UserModelPost>();

            AutoMapper.Mapper.CreateMap<User, UserModelResponse>()
                .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => calculator.RetrieveRanking(src)))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.GetScore()));

            AutoMapper.Mapper.AssertConfigurationIsValid();

        }

    }
}