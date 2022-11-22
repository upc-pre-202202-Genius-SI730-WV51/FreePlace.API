using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Repositories;
using FreePlace.API.Booking.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Repositories;

namespace FreePlace.API.Booking.Services;

public class PaymentService: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    
    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<PaymentResponse> SaveAsync(Payment payment)
    {
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(payment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"An error occurred while saving the payment: {e.Message}");
        }
    }

    public Task<PaymentResponse> UpdateAsync(int id, Payment payment)
    {
        throw new NotImplementedException();
    }
}