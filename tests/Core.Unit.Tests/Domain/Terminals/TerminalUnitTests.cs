using System;
using Xunit;
using FluentAssertions;
using Core.Domain.Terminals;
using Core.Domain.Shared;
using Core.Domain.Terminals.Localizations;
using Core.Unit.Tests.Shared;


namespace Core.Unit.Tests.Domain.Terminals
{    
    public class TerminalUnitTests
    {        
        public TerminalUnitTests()
        {            
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldCreateTerminal(string name, string latitude, string longitude)
        {                      
            var localization = Localization.Create(latitude, longitude);

            var terminal = Terminal.Create(name, localization);

            terminal.Should().NotBeNull();
            terminal.Name.Should().Be(name);            
            terminal.Localization.Should().NotBeNull();
            terminal.Localization.Latitude.Should().Be(latitude);
            terminal.Localization.Longitude.Should().Be(longitude);
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldCreateEqualsLocalization(string latitude, string longitude)
        {
            var localization = Localization.Create(latitude, longitude);

            var secondLocalization = Localization.Create(latitude, longitude);

            localization.Equals(secondLocalization).Should().BeTrue();

            localization.GetHashCode().Should().BeGreaterThan(0);
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldntCreateTerminalWithoutLocalization(string name)
        {                                  
            Action act = () => Terminal.Create(name, null);

            act.Should().Throw<DomainException>().Where(e => e.Message.StartsWith("'Localization' must not be empty."));
        }

        [Fact]        
        public void ShouldntCreateTerminalWithNameNull()
        {                                  
            Action act = () => Terminal.Create(null, null);

            act.Should().Throw<DomainException>().Where(e => e.Message.StartsWith("'Name' must not be empty."));
        }

        [Theory, AutoMoqDataAttribute]        
        public void ShouldntCreateTerminalWithoutLatitude(string longitude)
        {                                  
            Action act = () => Localization.Create(null, longitude);

            act.Should().Throw<DomainException>().Where(e => e.Message.StartsWith("'Latitude' must not be empty."));
        }

        [Theory, AutoMoqDataAttribute]        
        public void ShouldntCreateTerminalWithoutLongitude(string latitude)
        {                                  
            Action act = () => Localization.Create(latitude, null);

            act.Should().Throw<DomainException>().Where(e => e.Message.StartsWith("'Longitude' must not be empty."));
        }       
    }
}
