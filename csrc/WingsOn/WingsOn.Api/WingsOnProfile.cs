using AutoMapper;
using WingsOn.Api.Models;
using WingsOn.Domain.Booking;
using GenderType = WingsOn.Domain.Booking.GenderType;

namespace WingsOn.Api
{
    public class WingsOnProfile : Profile
    {
        public WingsOnProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<GenderType, Models.GenderType>().ReverseMap();
        }
    }
}
