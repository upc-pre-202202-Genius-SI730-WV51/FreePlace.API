using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> ListAsync();
    Task<IEnumerable<Review>> ListByUserIdAsync(int userId);
    Task<ReviewResponse> SaveAsync(Review review);
    Task<ReviewResponse> UpdateAsync(int id, Review review);
    Task<ReviewResponse> DeleteAsync(int id);
}