using System;
using Core.Domain.Shared;

namespace Core.Domain.Terminals.Localizations
{
    public class Localization : IValueObject
    {
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        private Localization() {}       

        public static Localization Create(string latitude, string longitude)
        {
            var localization = new Localization()
            {
                Latitude = latitude?.Trim(),
                Longitude = longitude?.Trim()
            };

            localization.ValidateAndThrow(new CreateLocalizationValidator());

            return localization;
        }
    }
}
