﻿using Data.Models.Models;
using Helpers.Extensions;

namespace Helpers.Move
{
    public class MoveSouth : IMove
    {
        public void SetCoordinate(Rover rover)
        {
            rover.AddCoordinates(0, -1);
        }
    }
}
