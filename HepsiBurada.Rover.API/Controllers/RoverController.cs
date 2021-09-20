using Data.Models.Mapping.Requests;
using Data.Models.Mapping.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBurada.Rover.API.Controllers
{
    [ApiController]
    [Route("rover")]
    public class RoverController : ControllerBase
    {
        private readonly IRoverService _roverService;

        public RoverController(IRoverService roverService)
        {
            _roverService = roverService;
        }

        [Route("")]
        [HttpPost]
        public Response<RoverResponse> GetRoverStatus(RoverRequest request)
        {
            return _roverService.GetRoverStatus(request);
        }
    }
}
