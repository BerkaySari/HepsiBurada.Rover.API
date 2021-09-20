using Data.Models.Mapping.Requests;
using Data.Models.Mapping.Responses;

namespace Services.Interfaces
{
    public interface IRoverService
    {
        Response<RoverResponse> GetRoverStatus(RoverRequest request);
    }
}
