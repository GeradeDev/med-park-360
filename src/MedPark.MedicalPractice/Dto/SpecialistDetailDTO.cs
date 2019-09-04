using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Dto
{
    public class SpecialistDetailDTO
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Guid PracticeId { get; set; }
    }
}
