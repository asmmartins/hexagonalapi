using Core.Domain.Aggregates.Terminals;
using Core.Unit.Tests.Shared;
using FluentAssertions;
using System;
using Xunit;

namespace Core.Unit.Tests.Domain.Terminals
{
    public class TerminalByIdSpecificationUnitTests
    {
        public TerminalByIdSpecificationUnitTests()
        {
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldCreateTerminalByIdSpecification(Guid id)
        {
            var specification = new TerminalByIdSpecification(id);

            specification.Should().NotBeNull();
            specification.Expression.Should().NotBeNull();
        }
    }
}
