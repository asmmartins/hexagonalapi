using Core.Domain.Shared.Specifications;
using System;

namespace Core.Domain.Aggregates.Terminals
{
    public class TerminalByIdSpecification : Specification<Terminal>
    {
        public TerminalByIdSpecification(Guid id)
            : base(terminal => terminal.Id == id)
        {
        }
    }
}