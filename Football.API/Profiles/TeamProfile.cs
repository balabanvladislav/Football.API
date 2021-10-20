using AutoMapper;
using Football.Data.Entities;
using Football.Data.Models;

namespace Football.API.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.City));

            CreateMap<Team, TeamWithoutPlayers>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.City));

            CreateMap<Player, PlayerDto>();
        }
    }
}
