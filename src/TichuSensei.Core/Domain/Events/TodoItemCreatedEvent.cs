using TichuSensei.Core.Domain.Entities;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item) => Item = item;

        public TodoItem Item { get; }
    }
}
