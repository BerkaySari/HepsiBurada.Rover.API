namespace Helpers.Rotate
{
    public static class RotateFactory
    {
        public static IRotator RotatorSelector(string direction)
        {
            if (direction == "W")
            {
                return new RotateFromWest();
            }
            else if (direction == "N")
            {
                return new RotateFromNorth();
            }
            else if (direction == "E")
            {
                return new RotateFromEast();
            }
            else
            {
                return new RotateFromSouth();
            }
        }
    }
}
