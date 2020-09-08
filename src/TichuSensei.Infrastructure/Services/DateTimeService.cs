using System;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
