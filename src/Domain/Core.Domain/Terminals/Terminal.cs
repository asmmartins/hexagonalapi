using System;
using Core.Domain.Terminals.Localizations;
using Core.Domain.Shared;

namespace Core.Domain.Terminals
{
    public class Terminal : IRootAgregate
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }        
        public Localization Localization { get; private set; }

        private Terminal() {}

        public static Terminal Create(string name, Localization localization)
        {
            var terminal = new Terminal()
            {
                Id = Guid.NewGuid(),
                Name = name?.Trim().ToLowerInvariant(),                
                Localization = localization
            };

            terminal.ValidateAndThrow(new CreateTerminalValidator());

            return terminal;
        }
    }
}
