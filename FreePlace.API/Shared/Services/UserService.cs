using AutoMapper;
using FreePlace.API.Security.Authorization.Handlers.Interfaces;
using FreePlace.API.Security.Domain.Services.Communication;
using FreePlace.API.Security.Exceptions;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Domain.Services;
using BCryptNet = BCrypt.Net.BCrypt;
using FreePlace.API.Shared.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.IdentityModel.Abstractions;

namespace FreePlace.API.Shared.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
    }


    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        // Find Username
        var user = await _userRepository.FindByUsernameAsync(model.Username);

        // Validate Password
        if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            // On Error throw Exception
            throw new AppException("Username or password is incorrect");

        // On Authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtHandler.GenerateToken(user);
        return response;
    }

    public async Task<PaymentResponse> Payment(PaymentRequest model)
    {
        var user = await _userRepository.FindByIdAsync(model.UserId);

        if(model.Card <= model.Value)
            throw new AppException("Your card have insufficient money.");

        var response = _mapper.Map<PaymentResponse>(user);
        response.Suscribed = true;
        response.TransactionId = 12; // Generate method - 12 is just representative
        response.Value = 30; // Value of subscription
        return response;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest model)
    {
        // Validate
        if (_userRepository.ExistsByUsername(model.Username))
            throw new AppException($"Username '{model.Username}' is already taken");

        // Map model to new usr object
        var user = _mapper.Map<User>(model);

        // Hash password
        user.PasswordHash = BCryptNet.HashPassword(model.Password);

        // Save user
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    public Task UpdateAsync(int id, RegisterRequest model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateRequest model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    // Helper methods
    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}