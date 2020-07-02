using System;
using System.Runtime.Serialization;

namespace Circa.Shared.Domain
{
    [Serializable]
    public class CircaException : Exception
    {
        public CircaException()
        {
        }

        public CircaException(string message) : base(message)
        {
        }

        public CircaException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CircaException(SerializationInfo info,
                              StreamingContext context) : base(info, context)
        {
        }
    }
}
