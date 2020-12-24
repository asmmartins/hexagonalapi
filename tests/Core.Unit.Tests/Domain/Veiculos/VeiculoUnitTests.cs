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
        [InlineData("MKP-4560", "Vermelho", "123456", "321654")]
        [InlineData("ASM-1990", "Amarelo", "654789", "987456")]        
        public void DeveCriarOVeiculo(string placa, string cor, string latitude, string longitude)
        {            
            var localizacao = Localizacao.Create(latitude, longitude);

            var veiculo = Veiculo.Create(placa, cor, localizacao);

            veiculo.Should().NotBeNull();
            veiculo.Placa.Should().Be(placa);
            veiculo.Cor.Should().Be(cor);
            veiculo.Localizacao.Should().NotBeNull();
            veiculo.Localizacao.Latitude.Should().Be(latitude);
            veiculo.Localizacao.Longitude.Should().Be(longitude);
        }        
    }
}
