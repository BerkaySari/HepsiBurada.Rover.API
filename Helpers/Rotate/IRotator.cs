using Data.Models.Models;

namespace Helpers.Rotate
{
    public interface IRotator
    {
        void RotateLeft(Rover rover);
        void RotateRight(Rover rover);
    }
}
