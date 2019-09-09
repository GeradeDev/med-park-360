using MedPark.Common.Types;
using MedPark.MedicalPractice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Queries
{
    public class AcceptedMedicalSchemeQuery : IQuery<List<AcceptedMedicalSchemeDTO>>
    {
        public Guid PracticeId { get; set; }
        public Guid SchemeId { get; set; }
    }
}
