using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.ParkingLots.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Repositories;

namespace FreePlace.API.ParkingLots.Services;

public class ReviewService: IReviewService
{
    private readonly IReviewsRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }

    public async Task<IEnumerable<Review>> ListByUserIdAsync(int userId)
    {
        return await _reviewRepository.FindByReviewIdAsync(userId);
    }

    public async Task<ReviewResponse> SaveAsync(Review review)
    {
        try
        {
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while saving the comment: {e.Message}");
        }
    }

    public async Task<ReviewResponse> UpdateAsync(int id, Review review)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(id);
        if (existingReview == null)
            return new ReviewResponse("Review not found");
        //existingCar.Plate = car.Plate;
        existingReview.Comment = review.Comment;

        try
        {
            _reviewRepository.Update(existingReview);
            await _unitOfWork.CompleteAsync();

            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while updating the review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> DeleteAsync(int id)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(id);
        if (existingReview == null)
            return new ReviewResponse("Review not found");

        try
        {
            _reviewRepository.Remove(existingReview);
            await _unitOfWork.CompleteAsync();

            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while deleting the review: {e.Message}");
        }
    }
}