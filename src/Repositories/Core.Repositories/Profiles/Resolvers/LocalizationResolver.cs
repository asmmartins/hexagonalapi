using AutoMapper;
using Core.Domain.Aggregates.Terminals;
using Core.Domain.Aggregates.Terminals.Localizations;
using Core.Repositories.DataModels;

namespace Core.Repositories.Profiles.Resolvers
{
    public class LocalizationResolver : IValueResolver<TerminalDataModel, Terminal, Localization>
    {
        public Localization Resolve(TerminalDataModel source, Terminal destination, Localization destMember, ResolutionContext context)
        {
            return Localization.Create(source.Latitude, source.Longitude);
        }
    }
}
