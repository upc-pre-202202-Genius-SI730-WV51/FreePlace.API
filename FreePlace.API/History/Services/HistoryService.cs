using FreePlace.API.History.Domain.Service;

namespace FreePlace.API.History.Services;

public class HistoryService : IHistoryService
{
    private readonly IBookingRepository _bookedRepository;
    private readonly IUnitOfWork _unitOfWork;
}