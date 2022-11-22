using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Booking.Resources;

public class SavePaymentResource
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public bool Status { get; set; }
    
    [Required]
    public long Card { get; set; }
}