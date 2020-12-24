using System;

namespace Core.Domain.Shared
{
    public interface IEntity
    {        
        Guid Id { get; }
    }
}
