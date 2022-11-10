using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Services.Communication;
using FreePlace.API.History.Domain.Repositories;
using FreePlace.API.History.Domain.Service;
using FreePlace.API.History.Domain.Service.Communication;
using FreePlace.API.Shared.Domain.Repositories;

namespace FreePlace.API.History.Services;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<IEnumerable<Domain.Models.History>> ListAsync()
    {
        return await _historyRepository.ListAsync();
    }
    
    public async Task<HistoryResponse> SaveAsync(Domain.Models.History history)
    {
        try
        {
            await _historyRepository.AddAsync(history);
            await _unitOfWork.CompleteAsync();
            return new HistoryResponse(history);
        }
        catch (Exception e)
        {
            return new HistoryResponse($"An error occurred while saving the booking: {e.Message}");
        }
    }
    
    public async Task<HistoryResponse> UpdateAsync(int id, Domain.Models.History history)
    {
        var existingHistory = await _historyRepository.FindByIdAsync(id);
        if (existingHistory == null)
            return new HistoryResponse("Booking not found");
        existingHistory.Status = history.Status;

        try
        {
            _historyRepository.Update(existingHistory);
            await _unitOfWork.CompleteAsync();

            return new HistoryResponse(existingHistory);
        }
        catch (Exception e)
        {
            return new HistoryResponse($"An error occurred while updating the booking: {e.Message}");
        }
    }
    
    public async Task<HistoryResponse> DeleteAsync(int id)
    {
        var existingHistory = await _historyRepository.FindByIdAsync(id);
        if (existingHistory == null)
            return new HistoryResponse("Booking not found");

        try
        {
            _historyRepository.Remove(existingHistory);
            await _unitOfWork.CompleteAsync();

            return new HistoryResponse(existingHistory);
        }
        catch (Exception e)
        {
            return new HistoryResponse($"An error occurred while deleting the booking: {e.Message}");
        }
    }
}