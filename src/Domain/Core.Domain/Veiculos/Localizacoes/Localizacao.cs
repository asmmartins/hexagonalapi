using System;
using Core.Domain.Shared;

namespace Core.Domain.Veiculos.Localizacoes
{
    public class Localizacao : IValueObject
    {
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        private Localizacao() {}       

        public static Localizacao Create(string latitude, string longitude)
        {
            var localizacao = new Localizacao()
            {
                Latitude = latitude?.Trim(),
                Longitude = longitude?.Trim()
            };

            return localizacao;
        }
    }
}
