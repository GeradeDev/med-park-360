using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class PendingRegistration : BaseIdentifiable
    {
        public PendingRegistration(Guid id) : base(id)
        {

        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public Guid PracticeId { get; set; }
        public Boolean IsAdmin { get; set; }
        public string OTP { get; set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}
