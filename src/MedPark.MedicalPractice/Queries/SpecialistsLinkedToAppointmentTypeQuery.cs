using MedPark.Common.Types;
using MedPark.MedicalPractice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Queries
{
    public class SpecialistsLinkedToAppointmentTypeQuery : IQuery<AppointmentTypeSpecialistDTO>
    {
        public Guid AppointmentTypeId { get; set; }
    }
}
