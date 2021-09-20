using Data.Models.Mapping.Requests;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Services.Interfaces;
using Services.Services;

namespace HepsiBurada.Rover.API.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private IRoverService _roverService;

        [SetUp]
        public void Setup()
        {
            #region register services
            var services = new ServiceCollection();

            services.AddTransient<IRoverService, RoverService>();

            var serviceProvider = services.BuildServiceProvider();

            _roverService = serviceProvider.GetService<IRoverService>();
            #endregion
        }


        [Test]
        public void GetRoverStatus_EmptyRequestException()
        {
            RoverRequest request = getRequest(5, 5, 1, 2, "N", "");
            var result =  _roverService.GetRoverStatus(request);
            Assert.That(result.Message, Is.EqualTo("Some parameters empty."));
        }

        [Test]
        public void GetRoverStatus_OutOfAreaException()
        {
            RoverRequest request = getRequest(5, 5, 6, 2, "N", "LMLMLMLMM");
            var result = _roverService.GetRoverStatus(request);
            Assert.That(result.Message, Is.EqualTo("Starting coordinates out of area."));
        }

        [Test]
        public void GetRoverStatus_TestCase1()
        {
            RoverRequest request = getRequest(5, 5, 1, 2, "N", "LMLMLMLMM");
            var result = _roverService.GetRoverStatus(request);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, result.Data.FinalX, "Final X Coordinate");
                Assert.AreEqual(3, result.Data.FinalY, "Final Y Coordinate");
                Assert.AreEqual("N", result.Data.FinalDirection, "Final Direction");
            });

        }

        [Test]
        public void GetRoverStatus_TestCase2()
        {
            RoverRequest request = getRequest(5, 5, 3, 3, "E", "MMRMMRMRRM");
            var result = _roverService.GetRoverStatus(request);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(5, result.Data.FinalX, "Final X Coordinate");
                Assert.AreEqual(1, result.Data.FinalY, "Final Y Coordinate");
                Assert.AreEqual("E", result.Data.FinalDirection, "Final Direction");
            });
        }



        #region private metods
        private RoverRequest getRequest(int areaX, int areaY, int startingX, int startingY, string direction, string mapping)
        {
            CoordinateRequest areaLength = new CoordinateRequest
            {
                X = areaX,
                Y = areaY
            };
            CoordinateRequest startingCoordinates = new CoordinateRequest
            {
                X = startingX,
                Y = startingY
            };

            return new RoverRequest
            {
                AreaLength = areaLength,
                StartingCoordinates = startingCoordinates,
                StartingDirection = direction,
                Mapping = mapping
            };
        }
        #endregion
    }
}
