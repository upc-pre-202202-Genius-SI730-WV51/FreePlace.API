using FreePlace.API.Booking.Domain.Models;

namespace FreePlace.API.Booking.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task AddAsync(Payment payment);
    Task<Payment> FindByIdAsync(int id);
    void Update(Payment payment);
}