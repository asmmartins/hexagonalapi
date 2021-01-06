using System;
using Xunit;
using FluentAssertions;
using Core.Domain.Shared;
using Core.Domain.Aggregates.Terminals.Localizations;
using Core.Unit.Tests.Shared;

namespace Core.Unit.Tests.Domain.Localizations
{    
    public class TerminalUnitTests
    {        
        public TerminalUnitTests()
        {            
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldCreateEqualsLocalization(string latitude, string longitude)
        {
            var localization = Localization.Create(latitude, longitude);

            var secondLocalization = Localization.Create(latitude, longitude);

            localization.Equals(secondLocalization).Should().BeTrue();

            localization.GetHashCode().Should().NotBe(0);
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
