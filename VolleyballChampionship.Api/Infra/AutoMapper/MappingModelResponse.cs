using AutoMapper;
using VolleyballChampionship.Api.Responses;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Api.Infra.AutoMapper
{
    public class MappingModelResponse : Profile
    {
        public MappingModelResponse()
        {
            CreateMap<ChampionshipInfo, ChampionshipResponse>();
            CreateMap<GroupInfo, GroupResponse>();
            CreateMap<TeamInfo, TeamResponse>();
            CreateMap<PlayerInfo, PlayerResponse>();
        }
    }
}
