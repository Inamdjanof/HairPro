using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(IEnumerable<string> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }

        public override string ToString()
        {
            return $"{Message}: {string.Join(", ", Errors)}";
        }
    }
}
