using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Models;

public class Review
{
    public int Id { set; get; }
    public string Comment { set; get; }
    public int likes { set; get; }
    public int dislikes { set; get; }

    //Relationships

    public int UserId { set; get; }
    public int ParkingId { set; get; }
    public Parking Parking;
    public User User;
}