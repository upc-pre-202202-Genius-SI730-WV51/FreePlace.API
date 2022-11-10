using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.History.Domain.Service.Communication;

public class HistoryResponse : BaseResponse<Models.History>
{
    public HistoryResponse(string message) : base(message) {}
    public HistoryResponse(Models.History resource) : base(resource) {}
}