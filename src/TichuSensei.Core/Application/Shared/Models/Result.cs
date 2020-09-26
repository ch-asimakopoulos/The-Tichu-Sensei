using System.Collections.Generic;
using System.Linq;

namespace TichuSensei.Core.Application.Shared.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(true, System.Array.Empty<string>());
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
