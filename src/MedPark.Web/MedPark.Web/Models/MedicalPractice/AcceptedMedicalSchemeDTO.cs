using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.MedicalPractice
{
    public class AcceptedMedicalSchemeDTO
    {
        public Guid Id { get; set; }
        public string SchemeName { get; set; }
        public Guid SchemeId { get; set; }
        public Guid PracticeId { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime DateEffective { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
