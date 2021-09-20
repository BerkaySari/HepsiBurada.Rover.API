namespace Helpers.Move
{
    public static class MoveFactory
    {
        public static IMove MoveSelector(string direction)
        {
            if (direction == "W")
            {
                return new MoveWest();
            }
            else if (direction == "N")
            {
                return new MoveNorth();
            }
            else if (direction == "E")
            {
                return new MoveEast();
            }
            else
            {
                return new MoveSouth();
            }
        }
    }
}
