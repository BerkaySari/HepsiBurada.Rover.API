using System;

namespace Helpers.Exceptions
{
    public class StartingCoordinatesOutOfAreaException : Exception
    {
        public StartingCoordinatesOutOfAreaException() : base("Starting coordinates out of area.")
        {

        }
    }
}
