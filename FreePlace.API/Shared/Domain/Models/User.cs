using System.Text.Json.Serialization;
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.Shared.Domain.Models;

public class User
{
    public long Id { set; get; }
    public string Name { set; get; }
    public string LastName { set; get; }
    public short Age { set; get; }
    public long Phone { set; get; }
    public string Username { set; get; }
    public bool Suscribed { set; get; } // True or False
    public bool TypeAccount { set; get; } // True represents Parking owner and False represents Normal User account

    [JsonIgnore]
    public string PasswordHash { set; get; }

    //Relationships

    public IList<Review> Reviews;
    public IList<Booked> Bookings;
    public IList<Parking> Parkings;
    public IList<Car> Cars;
    public Car Car;
    // Missing add Security, Booking and History ---
}