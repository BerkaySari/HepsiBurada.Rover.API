using System;

namespace Helpers.Exceptions
{
    public class SomeParametersEmptyException : Exception
    {
        public SomeParametersEmptyException() : base("Some parameters empty.")
        {

        }
    }
}
