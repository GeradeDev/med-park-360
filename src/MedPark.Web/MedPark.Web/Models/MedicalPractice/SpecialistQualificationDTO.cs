using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.MedicalPractice
{
    public class SpecialistQualificationDTO
    {
        public Guid Id { get; set; }
        public string QualificationName { get; set; }
        public string InstituteName { get; set; }
        public Guid InstituteId { get; set; }
        public DateTime YearObtained { get; set; }
        public Guid CredentialId { get; set; }
    }
}
