using TichuSensei.Core.Domain.Shared;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
