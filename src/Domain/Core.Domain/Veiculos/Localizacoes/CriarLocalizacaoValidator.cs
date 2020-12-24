using FluentValidation;

namespace Core.Domain.Veiculos.Localizacoes
{
    internal class CriarLocalizacaoValidator : AbstractValidator<Localizacao> 
    {
        public CriarLocalizacaoValidator() 
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
