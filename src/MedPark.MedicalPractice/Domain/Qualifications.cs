using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class Qualifications : IIdentifiable
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string QualificationName { get; set; }
        public string InstituteName { get; set; }
        public Guid InstituteId { get; set; }
        public DateTime YearObtained { get; set; }

        public Guid CredentialId { get; set; }
    }
}
