using System;
using Circa.Shared.Domain;

namespace Circa.User.Domain
{
    public class UserExceptionHelper
    {
        public static CircaException CreateUserException(string message)
        {
            return new CircaException(CircaHelper.DefaultCircaExceptionMessage(CircaServicesDescriptor.UserService),
                                     new CircaUserException(message));
        }
        public static CircaException CreateUserException(string message, Exception inner)
        {
            return new CircaException(CircaHelper.DefaultCircaExceptionMessage(CircaServicesDescriptor.UserService),
                                      new CircaUserException(message, inner));
        }
    }
}
