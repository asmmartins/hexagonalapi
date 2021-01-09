using FluentValidation;

namespace Core.Domain.Aggregates.Terminals
{
    internal class CreateTerminalValidator : AbstractValidator<Terminal>
    {
        public CreateTerminalValidator()
        {
            AddIdRule();
            AddNameRule();
            AddLocalizationRule();
        }

        private void AddIdRule()
        {
            RuleFor(t => t.Id).NotEmpty();
        }

        private void AddNameRule()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("'Name' must not be empty.");
            RuleFor(t => t.Name).Length(1, 50);
        }

        private void AddLocalizationRule()
        {
            RuleFor(t => t.Localization).NotNull().WithMessage("'Localization' must not be empty.");
        }
    }
}
