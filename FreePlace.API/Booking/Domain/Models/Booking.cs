using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.Booking.Domain.Models;

public class Booked
{
    public int Id { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime EndDate { set; get; }
    public bool Status { set; get; }

    //Relationships
    
    public long UserId { set; get; }
    public User User { set; get; }
    
    public int CarId { set; get; }
    public Car Car { set; get; }
    
    public int ParkingId { set; get; }
    public Parking Parking { set; get; }
}