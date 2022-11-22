using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services.Communication;

public class ReviewResponse: BaseResponse<Review>
{
    public ReviewResponse(string message) : base(message) {}

    public ReviewResponse(Review resource) : base(resource) {}
}