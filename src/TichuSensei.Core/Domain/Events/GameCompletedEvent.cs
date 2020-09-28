using TichuSensei.Core.Domain.Entities;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.Events
{
    public class GameCompletedEvent : DomainEvent
    {
        public GameCompletedEvent(Game game) => Game = game;

        public Game Game { get; }
    }
}
