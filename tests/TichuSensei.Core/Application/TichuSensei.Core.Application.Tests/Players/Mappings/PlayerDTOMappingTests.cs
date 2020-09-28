using AutoMapper;
using TichuSensei.Core.Domain.Entities;
using Xunit;

namespace TichuSensei.Core.Application.Tests.Players.Mappings
{
    /// <summary>
    /// PlayerDTO Mappings Test class.
    /// </summary>
    public class PlayerDTOMappingTests
    {
        /// <summary>
        /// Tries to map a Player class object to a PlayerDTO class object using Automapper's MapperConfiguration CreateMap. If CreateMap throws an exception then the test fails.
        /// </summary>
        [Fact]
        public void MapFromPlayerToPlayerDTO()
        {
            var configuration = new MapperConfiguration(cfg =>
                                cfg.CreateMap<Player, Application.Players.Models.DTOs.PlayerDTO>());

            configuration.AssertConfigurationIsValid();
        }

    }
}
