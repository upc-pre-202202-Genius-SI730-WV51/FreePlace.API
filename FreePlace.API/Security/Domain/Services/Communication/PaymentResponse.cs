namespace FreePlace.API.Security.Domain.Services.Communication;

public class PaymentResponse
{
    public int TransactionId { get; set; }
    public float Value { get; set; }
    public bool Suscribed { get; set; }
}