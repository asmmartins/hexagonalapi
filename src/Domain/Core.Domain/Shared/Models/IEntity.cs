using System;

namespace Core.Domain.Shared.Models
{
    public interface IEntity
    {        
        Guid Id { get; }
    }
}
