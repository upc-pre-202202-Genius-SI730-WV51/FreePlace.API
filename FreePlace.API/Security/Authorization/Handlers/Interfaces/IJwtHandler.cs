using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}