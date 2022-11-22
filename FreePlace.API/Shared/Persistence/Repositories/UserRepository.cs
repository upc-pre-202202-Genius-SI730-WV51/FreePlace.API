using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.Shared.Persistence.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }

    public User FindById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}