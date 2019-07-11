using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class PendingRegistration : IIdentifiable
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public Guid PracticeId { get; set; }
        public Boolean IsAdmin { get; set; }
        public Int32 OTP { get; set; }

        public PendingRegistration()
        {

        }
    }
}
