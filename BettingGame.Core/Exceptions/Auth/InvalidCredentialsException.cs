using System;

namespace BettingGame.Core.Exceptions.Auth
{
    public class InvalidCredentialsException : Exception
    {
        public readonly string ModelStateKey = "InvalidCredentialsException";
        private const string DefaultMessage = "The user has provided invalid login credentials";

        public InvalidCredentialsException(): base(DefaultMessage) { }
        public InvalidCredentialsException(string message) : base(message) { }
        public InvalidCredentialsException(string message, Exception inner) : base(message, inner) { }
    }
}
