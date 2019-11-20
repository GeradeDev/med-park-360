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

        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public string PatientSurname { get; private set; }
        public string PatientEmail { get; private set; }
        public string PatientMobile { get; private set; }

        public Guid SpecialistId { get; private set; }
        public string Title { get; private set; }
        public string SpecialistInitials { get; private set; }
        public string SpecialistSurname { get; private set; }
        public string SpecialistTel { get; private set; }
        public string SpecialistEmail { get; private set; }

        public Guid AppointmentType { get; private set; }

        public Guid? MedicalScheme { get; private set; }
        public bool HasMedicalAid { get; private set; }
        public string MedicalAidMembershipNo { get; private set; }

        public DateTime ScheduledDate { get; private set; }
        public bool IsPostponement { get; private set; }
        public string Comment { get; private set; }



        public void SetPatientDetails(string name, string surname, string mobile, string email, Guid patientId)
        {
            PatientName = name;
            PatientSurname = surname;
            PatientEmail = email;
            PatientMobile = mobile;
            PatientId = patientId;
        }

        public void SetSpecialistDetails(string specialistTitle, string specialistInitials, string specialistSurname, string specialistTel, string specialistEmail, Guid specialistId)
        {
            Title = specialistTitle;
            SpecialistInitials = specialistInitials;
            SpecialistSurname = specialistSurname;
            SpecialistTel = specialistTel;
            SpecialistEmail = specialistEmail;
            SpecialistId = specialistId;
        }

        public void SetAppointmentDetails(Guid appType, DateTime date, bool isPostponetment)
        {
            AppointmentType = appType;
            ScheduledDate = date;
            IsPostponement = IsPostponement;
        }

        public void SetComment(string comment)
        {
            Comment = comment;
        }

        public void SetMedicalScheme(Guid medScheme, string medSchemeNo)
        {
            MedicalScheme = medScheme;
            MedicalAidMembershipNo = medSchemeNo;
            HasMedicalAid = (!string.IsNullOrEmpty(medSchemeNo) ? true : false);
        }



        public override void Use()
        {
            base.Use();

            if (string.IsNullOrEmpty(SpecialistId.ToString()) || string.IsNullOrEmpty(PatientId.ToString()))
                throw new MedParkException("add_appointment_specialist_deatils_cannot_be_null", "Specialist details cannot be null.");
        }
    }
}
