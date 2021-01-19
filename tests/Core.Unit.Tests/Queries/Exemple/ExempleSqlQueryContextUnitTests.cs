using AutoFixture.Xunit2;
using Core.Querys.Exemple;
using Core.Unit.Tests.Shared;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace Core.Unit.Tests.Queries.Exemple
{
    public class ExempleSqlQueryContextUnitTests
    {
        [Theory]
        [InlineData("MariaDb", "SELECT * FROM ExempleMariaDbSqlQuery")]
        [InlineData("OracleDb", "SELECT * FROM ExempleOracleDbSqlQuery")]
        public void ShouldSetAndGetSqlQuery(string database, string query)
        {
            var configuration = new Mock<IConfiguration>();
            configuration.SetupGet(x => x[It.Is<string>(s => s == "Database")]).Returns(database);

            var exempleSqlQueryContext = new ExempleSqlQueryContext(configuration.Object);

            exempleSqlQueryContext.Should().NotBeNull();

            exempleSqlQueryContext.SetSqlQuery();

            var sqlQuery = exempleSqlQueryContext.GetSqlQuery();

            sqlQuery.Should().NotBeNull();
            sqlQuery.Value.Should().NotBeNullOrWhiteSpace();
            sqlQuery.Value.Should().Be(query);
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldnotSetSqlQueryWithoutDatabaseConfiguration([Frozen] IConfiguration configuration)
        {
            var exempleSqlQueryContext = new ExempleSqlQueryContext(configuration);

            exempleSqlQueryContext.Should().NotBeNull();

            Action act = () => exempleSqlQueryContext.SetSqlQuery();

            act.Should().Throw<ArgumentException>().WithMessage("Database not found");
        }
    }
}
