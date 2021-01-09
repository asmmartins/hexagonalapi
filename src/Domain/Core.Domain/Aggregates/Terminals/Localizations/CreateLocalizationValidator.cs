using FluentValidation;

namespace Core.Domain.Aggregates.Terminals.Localizations
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
            RuleFor(l => l.Latitude).NotEmpty().WithMessage("'Latitude' must not be empty.");
        }

        private void AddLongitudeRule()
        {
            RuleFor(l => l.Longitude).NotEmpty().WithMessage("'Longitude' must not be empty.");
        }
    }
}
