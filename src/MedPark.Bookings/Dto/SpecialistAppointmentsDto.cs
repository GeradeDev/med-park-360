using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class SpecialistAppointmentsDto
    {
        public SpecialistDto SpecialisttDetails { get; set; }
        public List<SpecialistAppointmentDto> BookingDetails { get; set; }

        public SpecialistAppointmentsDto()
        {
            SpecialisttDetails = new SpecialistDto();
            BookingDetails = new List<SpecialistAppointmentDto>();
        }
    }
}
