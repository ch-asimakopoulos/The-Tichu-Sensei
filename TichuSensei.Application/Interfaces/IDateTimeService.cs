using System;
using System.Collections.Generic;
using System.Text;

namespace TichuSensei.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
