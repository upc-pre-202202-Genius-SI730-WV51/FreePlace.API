using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.Booking.Domain.Services.Communication;

public class PaymentResponse: BaseResponse<Payment>
{
    public PaymentResponse(string message) : base(message){}
    public PaymentResponse(Payment resource) : base(resource){}
}