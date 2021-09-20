using Data.Models.Mapping.Requests;
using Data.Models.Mapping.Responses;
using Data.Models.Models;
using Helpers.Exceptions;
using Helpers.Move;
using Helpers.ResponseWrapper;
using Helpers.Rotate;
using Services.Interfaces;

namespace Services.Services
{
    public class RoverService : IRoverService
    {
        public Response<RoverResponse> GetRoverStatus(RoverRequest request)
        {
            if (parametersIsEmpty(request))
            {
                return ResponseWrapper<RoverResponse>.Create(new SomeParametersEmptyException());
            }
            if (startingCoordinatesOutOfArea(request))
            {
                return ResponseWrapper<RoverResponse>.Create(new StartingCoordinatesOutOfAreaException());
            }


            string mapping = request.Mapping;
            Rover rover = getRoverFromRoverRequest(request);

            IRotator rotator;
            IMove move;
            foreach (char map in mapping)
            {
                if (map == 'M')
                {
                    move = MoveFactory.MoveSelector(rover.Direction);
                    move.SetCoordinate(rover);
                }
                else if (map == 'R')
                {
                    rotator = RotateFactory.RotatorSelector(rover.Direction);
                    rotator.RotateRight(rover);
                }
                else if (map == 'L')
                {
                    rotator = RotateFactory.RotatorSelector(rover.Direction);
                    rotator.RotateLeft(rover);
                }
            }

            return getRoverResponseFromRover(rover);
        }


        #region private functions
        private Rover getRoverFromRoverRequest(RoverRequest request)
        {
            return new Rover
            {
                Coordinates = getCoordinatesFromCoordinateRequest(request.StartingCoordinates),
                Area = getCoordinatesFromCoordinateRequest(request.AreaLength),
                Direction = request.StartingDirection,
            };
        }

        private Coordinates getCoordinatesFromCoordinateRequest(CoordinateRequest request)
        {
            return new Coordinates
            {
                X = request.X,
                Y = request.Y
            };
        }

        private Response<RoverResponse> getRoverResponseFromRover(Rover rover)
        {
            RoverResponse response = new RoverResponse
            {
                FinalX = rover.Coordinates.X,
                FinalY = rover.Coordinates.Y,
                FinalDirection = rover.Direction
            };

            return ResponseWrapper<RoverResponse>.Create(response);
        }

        private bool parametersIsEmpty(RoverRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Mapping) || string.IsNullOrWhiteSpace(request.StartingDirection))
            {
                return true;
            }

            return false;
        }

        private bool startingCoordinatesOutOfArea(RoverRequest request)
        {
            if (request.StartingCoordinates.X < 0 || request.AreaLength.X < request.StartingCoordinates.X)
            {
                return true;
            }

            if (request.StartingCoordinates.Y < 0 || request.AreaLength.Y < request.StartingCoordinates.Y)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
