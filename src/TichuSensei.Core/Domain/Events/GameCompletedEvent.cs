using TichuSensei.Kernel;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Domain.Events
{
    public class GameCompletedEvent : DomainEvent
    {
        public GameCompletedEvent(Game game)
        {
            Game = game;
        }

        public Game Game { get; }
    }
}
