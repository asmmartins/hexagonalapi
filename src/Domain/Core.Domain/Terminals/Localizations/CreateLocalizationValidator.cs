using FluentValidation;

namespace Core.Domain.Terminals.Localizations
{
    internal class CreateLocalizationValidator : AbstractValidator<Localization> 
    {
        public CreateLocalizationValidator() 
        {
            AddLatitudeRule();
            AddLongitudeRule();            
        }

        private void AddLatitudeRule()
        {
            RuleFor(l => l.Latitude).NotNull();
            RuleFor(l => l.Latitude).NotEmpty();
        }

        private void AddLongitudeRule()
        {
            RuleFor(l => l.Longitude).NotNull();
            RuleFor(l => l.Longitude).NotEmpty();
        }
    }
}
