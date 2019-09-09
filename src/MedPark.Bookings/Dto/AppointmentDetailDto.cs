using MedPark.Bookings.Model.MedicalPracticeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class AppointmentDetailDto
    {
        public Guid SpecialistId { get; set; }

        public string SpecialistTitle { get; set; }
        public string SpecialistName { get; set; }
        public string SpecialistSurname { get; set; }
        public string SpecialistTel { get; set; }
        public string SpecialistEmail { get; set; }

        public PracticeDto Practice { get; set; }
        public PracticeAddressDTO Address { get; set; }

        public Guid PatientId { get; set; }

        public string AppointmentType { get; set; }
        public string MedicalScheme { get; set; }
        public string MedicalAidMembershipNo { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Comment { get; set; }
    }
}
