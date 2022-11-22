using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.ParkingLots.Persistence.Repositories;

public class ReviewRepository: BaseRepository, IReviewsRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public async Task<Review> FindByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
    }

    public async Task<IEnumerable<Review>> FindByReviewIdAsync(int userId)
    {
        return await _context.Reviews
        .Where(p => p.UserId == userId)
        .Include(p => p.User)
        .ToListAsync();
    }

    public void Update(Review review)
    {
        _context.Reviews.Update(review);
    }

    public void Remove(Review review)
    {
        _context.Reviews.Remove(review);
    }
}