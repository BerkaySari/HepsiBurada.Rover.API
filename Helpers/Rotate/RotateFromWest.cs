using Data.Models.Models;

namespace Helpers.Rotate
{
    public class RotateFromWest : IRotator
    {
        public void RotateLeft(Rover rover)
        {
            rover.Direction = "S";
        }

        public void RotateRight(Rover rover)
        {
            rover.Direction = "N";
        }
    }
}
