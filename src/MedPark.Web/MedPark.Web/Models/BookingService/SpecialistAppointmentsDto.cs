using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.BookingService
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
