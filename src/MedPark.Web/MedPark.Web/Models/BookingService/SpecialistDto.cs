using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.BookingService
{
    public class SpecialistDto
    {
        public Guid Id { get; protected set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Cellphone { get; private set; }
        public Guid PracticeId { get; private set; }
    }
}
