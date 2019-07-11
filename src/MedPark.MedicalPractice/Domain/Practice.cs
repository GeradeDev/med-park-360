using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class Practice : BaseIdentifiable
    {
        public Practice(Guid id) : base(id)
        {

        }

        public string PracticeName { get; set; }
        public string Slogan { get; private set; }
        public string Email { get; private set; }
        public string TelephonePrimary { get; private set; }
        public string TelephoneSecondary { get; private set; }
        public string Avatar { get; private set; }
        public string Website { get; private set; }

        public string LocationLongitude { get; private set; }
        public string LocationLatitude { get; private set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}
