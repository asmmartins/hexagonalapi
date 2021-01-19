using AutoMapper;
using Core.Domain.Aggregates.Terminals;
using Core.Repositories.DataModels;

namespace Core.Repositories.Profiles
{
    public class TerminalProfile : Profile
    {
        public TerminalProfile()
        {
            CreateMap<Terminal, TerminalDataModel>()
                .ForMember(
                    dest => dest.Latitude,
                    opt => opt.MapFrom(src => src.Localization.Latitude))
                .ForMember(
                    dest => dest.Longitude,
                    opt => opt.MapFrom(src => src.Localization.Longitude));

            CreateMap<TerminalDataModel, Terminal>()
                .ForPath(
                    dest => dest.Localization.Latitude,
                    opt => opt.MapFrom(src => src.Latitude))
                .ForPath(
                    dest => dest.Localization.Longitude,
                    opt => opt.MapFrom(src => src.Longitude));
        }
    }
}
