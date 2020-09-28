using AutoMapper;
using TichuSensei.Core.Domain.Entities;
using Xunit;

namespace TichuSensei.Core.Application.Tests.Players.Mappings
{
    /// <summary>
    /// PlayerEloRankingsDTO Mappings Test class.
    /// </summary>
    public class PlayerEloRankingsDTOMappingTests
    {
        /// <summary>
        /// Tries to map a Player class object to a PlayerEloRankingsDTO class object using Automapper's MapperConfiguration CreateMap. If CreateMap throws an exception then the test fails.
        /// </summary>
        [Fact]
        public void MapFromPlayerToPlayerEloRankingsDTO()
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
                                cfg.CreateMap<Player, Application.Players.Models.DTOs.PlayerEloRankingsDTO>());

            configuration.AssertConfigurationIsValid();
        }

    }
}
