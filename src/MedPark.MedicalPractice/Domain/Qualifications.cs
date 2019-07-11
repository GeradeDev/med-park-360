using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class Qualifications : BaseIdentifiable
    {
        public Qualifications(Guid id) : base(id)
        {

        }

        public string QualificationName { get; set; }
        public Guid InstituteId { get; set; }
        public DateTime YearObtained { get; set; }

        public Guid CredentialId { get; set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}
