using Data.Models.Models;
using Helpers.Extensions;

namespace Helpers.Move
{
    class MoveEast : IMove
    {
        public void SetCoordinate(Rover rover)
        {
            rover.AddCoordinates(1,0);
        }
    }
}
