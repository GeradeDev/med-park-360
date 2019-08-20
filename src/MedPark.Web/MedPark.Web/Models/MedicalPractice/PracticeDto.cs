using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.MedicalPractice
{
    public class PracticeDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string PracticeName { get; set; }
        public string Slogan { get; private set; }
        public string Email { get; private set; }
        public string TelephonePrimary { get; private set; }
        public string TelephoneSecondary { get; private set; }
        public string Avatar { get; private set; }
        public string Website { get; private set; }

        public string LocationLongitude { get; private set; }
        public string LocationLatitude { get; private set; }
    }
}
