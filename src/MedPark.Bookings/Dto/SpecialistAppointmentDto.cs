using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class SpecialistAppointmentDto
    {
        public DateTime Created { get; set; }
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}
