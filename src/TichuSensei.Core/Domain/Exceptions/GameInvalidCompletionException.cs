using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Domain.Exceptions
{
    public class GameInvalidCompletionException : Exception
    {
        public GameInvalidCompletionException(Game game, Exception ex) : base(ex.Message, ex)
        {
        }
    }
}
