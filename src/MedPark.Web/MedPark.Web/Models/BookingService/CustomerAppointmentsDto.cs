using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.BookingService
{
    public class CustomerAppointmentsDto
    {
        public CustomerDto PatientDetails { get; set; }
        public IEnumerable<AppointmentDto> BookingDetails { get; set; }

        public CustomerAppointmentsDto()
        {
            PatientDetails = new CustomerDto();
        }
    }
}
