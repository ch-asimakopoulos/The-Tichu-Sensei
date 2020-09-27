using TichuSensei.Core.Domain.Entities;
using TichuSensei.Kernel.BaseModels;

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
