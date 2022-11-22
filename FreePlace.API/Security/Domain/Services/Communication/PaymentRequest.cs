using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Security.Domain.Services.Communication;

public class PaymentRequest
{
    [Required]
    public int UserId { get; set; }
    public float Value { get; set; }
    public long Card { get; set; }
    
}