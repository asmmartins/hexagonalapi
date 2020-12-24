using FluentValidation;

namespace Core.Domain.Veiculos
{
    internal class CriarVeiculoValidator : AbstractValidator<Veiculo> 
    {
        public CriarVeiculoValidator() 
        {
            AddIdRule();
            AddPlacaRule();
            AddCorRule();
            AddLocalizacaoRule();
        }

        private void AddIdRule()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Id).NotEmpty();
        }

        private void AddPlacaRule()
        {
            RuleFor(v => v.Placa).NotNull();
            RuleFor(v => v.Placa).NotEmpty();
        }

        private void AddCorRule()
        {
            RuleFor(v => v.Cor).NotNull();
            RuleFor(v => v.Cor).NotEmpty();
        }

        private void AddLocalizacaoRule()
        {
            RuleFor(v => v.Localizacao).NotNull();            
        }
    }
}
