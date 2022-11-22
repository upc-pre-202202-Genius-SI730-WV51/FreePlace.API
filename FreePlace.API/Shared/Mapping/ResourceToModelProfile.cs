using AutoMapper;
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Resources;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Security.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.X509;

namespace FreePlace.API.Shared.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCarResource, Car>();

        CreateMap<SaveParkingResource, Parking>();

        CreateMap<SaveUserResource, User>();

        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) &&
                        string.IsNullOrEmpty((string)property))
                        return false;
                    return true;
                }
            ));

        CreateMap<PaymentRequest, User>();

        CreateMap<RegisterRequest, User>();

        CreateMap<SaveBookingResource, Booked>();
    }
}