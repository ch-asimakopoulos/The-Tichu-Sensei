using System;
using System.Collections.Generic;
using TichuSensei.Core.Domain.Enums;
using TichuSensei.Core.Domain.Events;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.Entities
{
    public class TodoItem : TrackingChangesEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public TodoList List { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new TodoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
