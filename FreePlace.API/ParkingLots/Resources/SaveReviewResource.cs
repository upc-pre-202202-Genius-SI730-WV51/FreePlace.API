using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.ParkingLots.Resources;

public class SaveReviewResource
{
    [Required]
    [MaxLength(500)]
    public string Comment { get; set; }
}