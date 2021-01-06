using System;
using System.Linq.Expressions;

namespace Core.Domain.Shared.Specifications
{
    public abstract class Specification<T>
    {
        public Expression<Func<T, bool>> Expression { get; private set; }

        protected Specification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }
    }
}