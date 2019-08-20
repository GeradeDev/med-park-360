using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.MedicalPractice
{
    public class SpecialistDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Avatar { get; set; }
        public Guid? SpecialityId { get; set; }
        public Guid PracticeId { get; set; }
        public Boolean IsAdmin { get; set; }
        public Boolean IsVerfied { get; set; }
        public Boolean Active { get; set; }
    }
}
