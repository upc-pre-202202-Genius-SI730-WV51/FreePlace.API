using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Repositories;

public interface IReviewsRepository
{
    Task<IEnumerable<Review>> ListAsync();
    Task AddAsync(Review review);
    Task<Review> FindByIdAsync(int id);
    Task<IEnumerable<Review>> FindByReviewIdAsync(int userId);
    void Update(Review review);
    void Remove(Review review);
}