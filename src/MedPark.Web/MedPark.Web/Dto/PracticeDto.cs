using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Dto
{
    public class PracticeDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string PracticeName { get; set; }
        public string Slogan { get; set; }
        public string Email { get; set; }
        public string TelephonePrimary { get; set; }
        public string TelephoneSecondary { get; set; }
        public string Avatar { get; set; }
        public string Website { get; set; }

        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
    }
}
