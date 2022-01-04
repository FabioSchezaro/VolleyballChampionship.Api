using AutoMapper;
using VolleyballChampionship.Api.Requests;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Api.Infra.AutoMapper
{
    public class MappingModelRequest : Profile
    {
        public MappingModelRequest()
        {
            CreateMap<ChampionshipRequest, ChampionshipInfo>();
            CreateMap<GroupRequest, GroupInfo>();
            CreateMap<TeamRequest, TeamInfo>();
            CreateMap<PlayerRequest, PlayerInfo>();
        }
    }
}
