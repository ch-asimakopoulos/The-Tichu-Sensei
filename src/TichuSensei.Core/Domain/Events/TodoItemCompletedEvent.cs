using TichuSensei.Core.Domain.Shared;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
