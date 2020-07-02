using System;
using System.Runtime.Serialization;

namespace Circa.User.Domain
{
    [Serializable]
    public class CircaUserException : Exception
    {
        
        public CircaUserException()
        {
        }

        public CircaUserException(string message) : base(message)
        {
        }

        public CircaUserException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CircaUserException(SerializationInfo info,
                              StreamingContext context) : base(info, context)
        {
        }
    }
}
