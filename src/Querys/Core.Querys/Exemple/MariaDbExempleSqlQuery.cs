using Core.Querys.Abstractions.Shared;

namespace Core.Querys
{
    public class MariaDbExempleSqlQuery : ISqlQuery
    {
        public string Value => "SELECT * FROM ExempleMariaDbSqlQuery";
    }
}
