using MedPark.Common.Types;
using MedPark.MedicalPractice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Queries
{
    public class AppointmentTypeQuery : IQuery<List<AppointmentTypeDTO>>, IQuery<SpecialistAppointmentTypesDTO>
    {
        public Guid SpecialistId { get; set; }
        public Guid AppointmentTypeId { get; set; }
    }
}
