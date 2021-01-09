using Core.Domain.Aggregates.Terminals.Localizations;
using Core.Domain.Shared.Models;
using Core.Domain.Shared.Validators;
using System;

namespace Core.Domain.Aggregates.Terminals
{
    public class Terminal : IRootAggregate
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Localization Localization { get; private set; }

        private Terminal() { }

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
