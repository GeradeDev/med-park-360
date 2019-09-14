using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
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
        public string Avatar { get; private set; }
        public Guid? SpecialityId { get; private set; }
        public Guid PracticeId { get; private set; }
        public Boolean IsAdmin { get; private set; }
        public Boolean IsVerfied { get; private set; }
        public Boolean Active { get; private set; }
        public TimeSpan AppointmentDuration { get; private set; }

        public void Create(string firstname, string surname, string email, string title = "Dr")
        {
            FirstName = firstname;
            Surname = surname;
            Email = email;
            Title = title;
        }

        public void SetCellphone(string cell)
        {
            Cellphone = cell;
        }

        public void SignUp(Guid practiceId, bool isAdmin)
        {
            PracticeId = practiceId;
            IsAdmin = isAdmin;
            Active = true;
        }

        public void SetAppointmentDuration(Guid practiceId, bool isAdmin)
        {
            PracticeId = practiceId;
            IsAdmin = isAdmin;
            Active = true;
        }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}
