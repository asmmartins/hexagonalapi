using AutoMapper;
using Core.Domain.Aggregates.Terminals;
using Core.Domain.Aggregates.Terminals.Localizations;
using Core.Repositories.DataModels;
using Core.Repositories.Profiles;
using Core.Unit.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Core.Unit.Tests.Repositories.DataModels
{
    public class TerminalDataModelUnitTests
    {
        private readonly IMapper _mapper;

        public TerminalDataModelUnitTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TerminalProfile>();
            }).CreateMapper();
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldMapperTerminalToDataModel(string name, string latitude, string longitude)
        {
            var localization = Localization.Create(latitude, longitude);
            var terminal = Terminal.Create(name, localization);

            terminal.Should().NotBeNull();

            var terminalDto = _mapper.Map<Terminal, TerminalDataModel>(terminal);

            terminalDto.Should().NotBeNull();
            terminalDto.Id.Should().NotBeEmpty();
            terminalDto.Name.Should().Be(terminal.Name);
            terminalDto.Latitude.Should().Be(terminal.Localization.Latitude);
            terminalDto.Longitude.Should().Be(terminal.Localization.Longitude);
        }

        [Theory, AutoMoqDataAttribute]
        public void ShouldMapperTerminalDataModelToDomainModel(TerminalDataModel terminalDataModel)
        {                       
            var terminal = _mapper.Map<TerminalDataModel, Terminal>(terminalDataModel);

            terminal.Should().NotBeNull();
            terminal.Id.Should().NotBeEmpty();
            terminal.Name.Should().Be(terminalDataModel.Name);
            terminal.Localization.Should().NotBeNull();
            terminal.Localization.Latitude.Should().Be(terminalDataModel.Latitude);
            terminal.Localization.Longitude.Should().Be(terminalDataModel.Longitude);
        }
    }
}
