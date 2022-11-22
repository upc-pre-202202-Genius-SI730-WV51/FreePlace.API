using FreePlace.API.Security.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Domain.Services.Communication;

namespace FreePlace.API.Shared.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<PaymentResponse> Payment(PaymentRequest model);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, RegisterRequest model);
    Task DeleteAsync(int id);
}