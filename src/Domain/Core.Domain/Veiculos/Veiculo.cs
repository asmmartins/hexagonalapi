using System;
using Core.Domain.Veiculos.Localizacoes;
using Core.Domain.Shared;

namespace Core.Domain.Veiculos
{
    public class Veiculo : IRootAgregate
    {
        public Guid Id { get; private set; }
        public string Placa { get; private set; }
        public string Cor { get; private set; }
        public Localizacao Localizacao { get; private set; }

        private Veiculo() {}

        public static Veiculo Create(string placa, string cor, Localizacao localizacao)
        {
            var veiculo = new Veiculo()
            {
                Id = Guid.NewGuid(),
                Placa = placa?.Trim(),
                Cor = cor?.Trim(),
                Localizacao = localizacao
            };

            veiculo.ValidateAndThrow(new CriarVeiculoValidator());

            return veiculo;
        }
    }
}
