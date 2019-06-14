using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class AcceptedMedicalScheme : IIdentifiable
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string SchemeName { get; set; }
        public Guid SchemeId { get; set; }
        public Guid PracticeId { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime DateEffective { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
