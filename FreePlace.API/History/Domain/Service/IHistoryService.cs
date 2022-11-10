using FreePlace.API.History.Domain.Service.Communication;

namespace FreePlace.API.History.Domain.Service;

public interface IHistoryService
{
    Task<IEnumerable<Models.History>> ListAsync();
    Task<HistoryResponse> SaveAsync(Models.History booked);
    Task<HistoryResponse> UpdateAsync(int id, Models.History booked);
    Task<HistoryResponse> DeleteAsync(int id);
}