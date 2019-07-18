using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Domain
{
    public class Appointment : BaseIdentifiable
    {
        public Appointment(Guid id) : base(id)
        {

        }

        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientEmail { get; set; }
        public string PatientMobile { get; set; }

        public Guid SpecialistId { get; set; }
        public string Title { get; set; }
        public string SpecialistInitials { get; set; }
        public string SpecialistSurname { get; set; }
        public string SpecialistTel { get; set; }
        public string SpecialistEmail { get; set; }

        public Guid AppointmentType { get; set; }

        public bool HasMedicalAid { get; set; }
        public Guid? MedicalAidMembershipNo { get; set; }

        public DateTime ScheduledDate { get; set; }
        public bool IsPostponement { get; set; }
    }
}
