using System;
using System.Collections.Generic;
using Core.Domain.Shared;

namespace Core.Domain.Terminals.Localizations
{
    public class Localization : ValueObject
    {
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }         

        protected Localization() {}     

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

        protected override IEnumerable<object> GetEqualsProperties()
        {
            yield return Latitude;
            yield return Longitude;            
        }   
    }
}
