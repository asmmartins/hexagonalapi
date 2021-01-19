using AutoMapper;
using Core.Domain.Aggregates.Terminals;
using Core.Repositories.DataModels;
using Core.Repositories.Profiles.Resolvers;

namespace Core.Repositories.Profiles
{
    public class TerminalProfile : Profile
    {
        public TerminalProfile()
        {
            CreateMap<TerminalDataModel, Terminal>()
                .ForMember(
                    dest => dest.Localization,
                    opt => opt.MapFrom<LocalizationResolver>());

            CreateMap<Terminal, TerminalDataModel>()
                .ForMember(
                    dest => dest.Latitude,
                    opt => opt.MapFrom(src => src.Localization.Latitude))
                .ForMember(
                    dest => dest.Longitude,
                    opt => opt.MapFrom(src => src.Localization.Longitude));
        }
    }
}
