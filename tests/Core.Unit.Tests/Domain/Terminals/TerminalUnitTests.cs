using System;
using Xunit;
using FluentAssertions;
using Core.Domain.Aggregates.Terminals;
using Core.Domain.Shared;
using Core.Domain.Aggregates.Terminals.Localizations;
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
    }
}
