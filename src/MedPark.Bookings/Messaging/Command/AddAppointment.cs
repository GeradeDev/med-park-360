using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Messaging.Command
{
    public class AddAppointment : ICommand
    {
        public Guid AppointmentId { get; }
        public Guid PatientId { get; }
        public Guid SpecialistId { get; }
        public Guid AppointmentType { get; }
        public string MedicalAidMembershipNo { get; }
        public DateTime ScheduledDate { get; }
        public bool IsPostponement { get; }
        public string Comment { get; }
        public Guid? MedicalScheme { get; }

        [JsonConstructor]
        public AddAppointment(Guid appointmentId, Guid patientId, Guid specialistId, Guid appointmentType, string medicalAidMembershipNo, DateTime scheduledDate, Boolean isPostponement, string comment, Guid? medicalScheme)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            SpecialistId = specialistId;
            AppointmentType = appointmentType;
            MedicalAidMembershipNo = medicalAidMembershipNo;
            ScheduledDate = scheduledDate;
            IsPostponement = isPostponement;
            Comment = comment;
            MedicalScheme = medicalScheme;
        }
    }
}
