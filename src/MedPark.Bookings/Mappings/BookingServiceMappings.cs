using AutoMapper;
using MedPark.Bookings.Domain;
using MedPark.Bookings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Mappings
{
    public class BookingServiceMappings : Profile
    {
        public BookingServiceMappings()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, SpecialistAppointmentDto>();

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<Specialist, SpecialistDto>();
            CreateMap<Appointment, AppointmentDetailDto>();            
        }
    }
}
