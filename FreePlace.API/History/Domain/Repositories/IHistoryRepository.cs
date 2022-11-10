using FreePlace.API.History.Domain.Models;

namespace FreePlace.API.History.Domain.Repositories;

public interface IHistoryRepository
{
    Task<IEnumerable<Models.History>> ListAsync();
    Task AddAsync(Models.History history);
    Task<Models.History> FindByIdAsync(int id);
    void Update(Models.History history);
    void Remove(Models.History history);
}