using MedPark.Common;
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
    }
}
