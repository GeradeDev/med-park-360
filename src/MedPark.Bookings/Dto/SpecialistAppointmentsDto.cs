using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class SpecialistAppointmentsDto
    {
        public SpecialistDto SpecialisttDetails { get; set; }
        public IEnumerable<AppointmentDto> BookingDetails { get; set; }

        public SpecialistAppointmentsDto()
        {
            SpecialisttDetails = new SpecialistDto();
        }
    }
}
