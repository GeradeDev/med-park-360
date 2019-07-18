using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Dto
{
    public class SpecialistAppointmentTypesDTO
    {
        public Guid SpecialistId { get; set; }
        public string SpecialistName { get; set; }
        public List<AppointmentTypeDTO> TypesLinkedToSpecilaist { get; set; }

        public SpecialistAppointmentTypesDTO()
        {
            TypesLinkedToSpecilaist = new List<AppointmentTypeDTO>();
        }
    }
}
