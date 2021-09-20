using Data.Models.Models;

namespace Helpers.Rotate
{
    public class RotateFromSouth : IRotator
    {
        public void RotateLeft(Rover rover)
        {
            rover.Direction = "E";
        }

        public void RotateRight(Rover rover)
        {
            rover.Direction = "W";
        }
    }
}
