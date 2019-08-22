using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class SpecialistAppointmentType : BaseIdentifiable
    {
        public SpecialistAppointmentType(Guid id) : base(id)
        {

        }

        public Guid SpecialistId { get; private set; }
        public Guid AppointmenyTypeId { get; private set; }

        public void Create(Guid specialistId, Guid appTypeId)
        {
            SpecialistId = specialistId;
            AppointmenyTypeId = appTypeId;
        }

        public override void Use()
        {
            UpdatedModified();
        }
    }
}
