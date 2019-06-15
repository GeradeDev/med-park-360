using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class Specialist : IIdentifiable
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Cellphone { get; private set; }
        public string Avatar { get; private set; }
        public Guid? SpecialityId { get; private set; }
        public Guid PracticeId { get; private set; }
        public Boolean IsAdmin { get; private set; }
        public Boolean IsVerfied { get; private set; }
        public Boolean Active { get; private set; }

        public Specialist(Guid id)
        {
            Id = id;
        }

        public void Create(string firstname, string surname, string email)
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            FirstName = firstname;
            Surname = surname;
            Email = email;
        }
    }
}
