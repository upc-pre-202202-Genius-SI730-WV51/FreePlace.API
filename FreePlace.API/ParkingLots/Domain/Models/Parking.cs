using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Booking.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Models;

public class Parking
{
    public int Id { set; get; }
    public int Capacity { set; get; }
    public string Description { set; get; }
    public string Ubication { set; get; }
    public float Price { set; get; }

    //Relationships
    public int CarId { set; get; }
    public Car Car;
    public IList<Car> Cars;
    public int BookingId { set; get; }
    public IList<Booked> Bookings;
    public int ReviewId { set; get; }
    public IList<Review> Reviews;

    //User from Shared
    public long UserId { set; get; }
    public User User;

}