using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;

namespace FreePlace.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}