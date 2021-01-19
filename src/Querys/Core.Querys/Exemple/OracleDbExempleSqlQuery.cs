using Core.Querys.Abstractions.Shared;

namespace Core.Querys
{
    public class OracleDbExempleSqlQuery : ISqlQuery
    {
        public string Value => "SELECT * FROM ExempleOracleDbSqlQuery";
    }
}
