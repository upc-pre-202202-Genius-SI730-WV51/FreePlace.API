using AutoMapper;
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Resources;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Security.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Resources;

namespace FreePlace.API.Shared.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Car, CarResource>();

        CreateMap<Parking, ParkingResource>();

        CreateMap<User, UserResource>();

        CreateMap<User, AuthenticateResponse>();

        CreateMap<User, PaymentResponse>();

        CreateMap<Booked, BookingResource>();
    }
}