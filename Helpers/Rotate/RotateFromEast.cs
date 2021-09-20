using Data.Models.Models;

namespace Helpers.Rotate
{
    public class RotateFromEast : IRotator
    {
        public void RotateLeft(Rover rover)
        {
            rover.Direction = "N";
        }

        public void RotateRight(Rover rover)
        {
            rover.Direction = "S";
        }
    }
}
