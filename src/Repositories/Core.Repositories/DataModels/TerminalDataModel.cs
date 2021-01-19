using System;

namespace Core.Repositories.DataModels
{
    public class TerminalDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }        
    }
}
