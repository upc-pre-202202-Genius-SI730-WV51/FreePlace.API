using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.History.Domain.Models;

public class History
{
    public int Id { set; get; }
    public string Status { set; get; }
    
    //Relationships
    
    public long UserId { set; get; }
    public User User { set; get; }
    
    public int CarId { set; get; }
    public Car Car { set; get; }
    
    public int ParkingId { set; get; }
    public Parking Parking { set; get; }
    
    public int BookingId { set; get; }
    public Booked Booking { set; get; }
}