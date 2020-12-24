using System;
using Xunit;
using FluentAssertions;
using Core.Domain.Veiculos;
using Core.Domain.Veiculos.Localizacoes;

namespace Core.Unit.Tests.Domain.Veiculos
{
    public class VeiculoUnitTests
    {
        [Theory]
        [InlineData("MKP-4560", "Vermelho")]
        [InlineData("ASM-1990", "Amarelo")]        
        public void DeveCriarOVeiculo(string placa, string cor)
        {
            var veiculo = Veiculo.Create(placa, cor, null);

            veiculo.Should().NotBeNull();
            veiculo.Placa.Should().Be(placa);
            veiculo.Cor.Should().Be(cor);
            veiculo.Localizacao.Should().BeNull();
        }        
    }
}
