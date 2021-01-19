using Core.Querys.Abstractions.Shared;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Querys.Exemple
{
    public sealed class ExempleSqlQueryContext : IExempleSqlQueryContext
    {
        private readonly IConfiguration _configuration;

        private ISqlQuery _sqlQuery;

        public ExempleSqlQueryContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ISqlQuery GetSqlQuery() => _sqlQuery;

        public void SetSqlQuery()
        {
            _sqlQuery = (_configuration["Database"]) switch
            {
                "MariaDb" => new MariaDbExempleSqlQuery(),
                "OracleDb" => new OracleDbExempleSqlQuery(),
                _ => throw new ArgumentException("Database not found"),
            };
        }
    }
}
