namespace Data.Models.Mapping.Requests
{
    public class RoverRequest
    {
        public CoordinateRequest AreaLength { get; set; }
        public CoordinateRequest StartingCoordinates { get; set; }
        public string StartingDirection { get; set; }
        public string Mapping { get; set; }
    }
}
