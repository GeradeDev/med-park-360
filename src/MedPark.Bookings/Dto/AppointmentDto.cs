using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class AppointmentDto
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid SpecialistId { get; set; }
        public string Title { get; set; }
        public string SpecialistInitials { get; set; }
        public string SpecialistSurname { get; set; }
        public string SpecialistTel { get; set; }
        public string SpecialistEmail { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}
