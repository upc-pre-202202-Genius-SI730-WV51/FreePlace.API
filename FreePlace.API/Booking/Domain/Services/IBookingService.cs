using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Services.Communication;

namespace FreePlace.API.Booking.Domain.Services;

public interface IBookingService
{
    Task<IEnumerable<Booked>> ListAsync();
    Task<BookingResponse> SaveAsync(Booked booked);
    Task<BookingResponse> UpdateAsync(int id, Booked booked);
    Task<BookingResponse> DeleteAsync(int id);
}