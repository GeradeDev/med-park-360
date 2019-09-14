using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Domain
{
    public class Specialist : BaseIdentifiable
    {
        public Specialist(Guid id) : base(id)
        {

        }

        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Cellphone { get; private set; }
        public Guid PracticeId { get; private set; }

        public void Create(string firstname, string surname, string email, string title = "Dr")
        {
            FirstName = firstname;
            Surname = surname;
            Email = email;
            Title = title;
        }

        public void SignUp(Guid practiceId)
        {
            PracticeId = practiceId;
        }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}
