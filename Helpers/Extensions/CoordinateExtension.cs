using Data.Models.Models;

namespace Helpers.Extensions
{
    public static class CoordinateExtension
    {
        public static void AddCoordinates(this Rover rover, int addingX, int addingY)
        {
            rover.Coordinates.X += addingX;
            rover.Coordinates.Y += addingY;
        }
    }
}
