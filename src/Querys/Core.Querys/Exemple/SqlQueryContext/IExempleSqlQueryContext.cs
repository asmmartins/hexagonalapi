using Core.Querys.Abstractions.Shared;

namespace Core.Querys.Exemple
{
    public interface IExempleSqlQueryContext
    {
        void SetSqlQuery();

        ISqlQuery GetSqlQuery();
    }
}
