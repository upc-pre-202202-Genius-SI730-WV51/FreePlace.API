using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Repositories;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.Booking.Persistence.Repositories;

public class PaymentRepository: BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public async Task<Payment> FindByIdAsync(int id)
    { 
        return await _context.Payments.FindAsync(id);
    }

    public void Update(Payment payment)
    {
        _context.Payments.Update(payment);
    }
}