using Data.Models.Models;

namespace Helpers.Rotate
{
    public class RotateFromNorth : IRotator
    {
        public void RotateLeft(Rover rover)
        {
            rover.Direction = "W";
        }

        public void RotateRight(Rover rover)
        {
            rover.Direction = "E";
        }
    }
}
