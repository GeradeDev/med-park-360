using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands
{
    [MessageNamespace("medical-practice")]
    public class LinkSpecialistAppointmentType : ICommand
    {
        public Guid SpecialistId { get; }
        public Guid AppointmentTypeId { get; }

        [JsonConstructor]
        public LinkSpecialistAppointmentType(Guid specialistId, Guid appointmentTypeId)
        {
            SpecialistId = specialistId;
            AppointmentTypeId = appointmentTypeId;
        }
    }
}
