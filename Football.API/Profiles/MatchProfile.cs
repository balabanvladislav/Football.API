using AutoMapper;
using Football.Data.Entities;
using Football.Data.Models;

namespace Football.API.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.FirstTeam, opt => opt.MapFrom(src => src.FirstTeam.Name))
                .ForMember(dest => dest.SecondTeam, opt => opt.MapFrom(src => src.SecondTeam.Name))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.City));

        }
    }
}
