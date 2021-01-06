using System;
using Core.Domain.Shared.Specifications;

namespace Core.Domain.Aggregates.Terminals
{
    public class TerminalByIdSpecification : Specification<Terminal>
    {                
        public TerminalByIdSpecification(Guid id) 
            :base(terminal => terminal.Id == id)
        {            
        }
    }
}