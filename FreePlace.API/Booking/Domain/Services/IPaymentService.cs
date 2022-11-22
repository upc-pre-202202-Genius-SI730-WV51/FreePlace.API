using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Security.Domain.Services.Communication;

namespace FreePlace.API.Booking.Domain.Services.Communication;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<PaymentResponse> SaveAsync(Payment payment);
    Task<PaymentResponse> UpdateAsync(int id, Payment payment);
}