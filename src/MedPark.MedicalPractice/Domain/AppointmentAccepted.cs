using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class AppointmentAccepted : BaseIdentifiable
    {
        public AppointmentAccepted(Guid id) : base(id)
        {

        }

        public Guid AppointmentTypeId { get; set; }
        public Guid SpecialistId { get; set; }
        public bool Enabled { get; set; }

        public void Create(Guid appointmentTypeId, Guid specialistId)
        {
            AppointmentTypeId = appointmentTypeId;
            SpecialistId = specialistId;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public override void Use()
        {
            if (AppointmentTypeId == Guid.Empty)
                throw new MedParkException("appointment_type_empty", $"The appointment type id is required and cannot be empty.");

            if (SpecialistId == Guid.Empty)
                throw new MedParkException("sepcialist_id_empty", $"The specialist id is required and cannot be empty.");

            UpdatedModified();
        }
    }
}
