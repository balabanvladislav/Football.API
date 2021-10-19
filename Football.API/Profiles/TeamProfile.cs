using Football.Data.Entities;
using Football.Data.Models;
using AutoMapper;

namespace Football.API.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.City));
                  
        }
    }
}
