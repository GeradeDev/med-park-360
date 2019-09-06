using MedPark.Common;
using MedPark.Common.Types;
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
        public string MedicalAidMembershipNo { get; set; }

        public DateTime ScheduledDate { get; set; }
        public bool IsPostponement { get; set; }

        public void SetPatientDetails(string name, string surname, string mobile, string email)
        {
            if (name is null || surname is null || mobile is null || email is null)
                throw new MedParkException("add_appointment_customer_deatils_cannot_be_null", "Customer details cannot be null.");

            PatientName = name;
            PatientSurname = surname;
            PatientEmail = email;
            PatientMobile = mobile;
        }

        public void SetSpecialistDetails(string specialistTitle, string specialistInitials, string specialistSurname, string specialistTel, string specialistEmail)
        {

            if (specialistTitle is null || specialistInitials is null || specialistSurname is null || specialistTel is null || specialistEmail is null)
                throw new MedParkException("add_appointment_specialist_deatils_cannot_be_null", "Specialist details cannot be null.");

            Title = specialistTitle;
            SpecialistInitials = specialistInitials;
            SpecialistSurname = specialistSurname;
            SpecialistTel = specialistTel;
            SpecialistEmail = specialistEmail;
        }
    }
}
