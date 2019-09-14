using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class UpdateSpecialistDetails : ICommand
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Cellphone { get; private set; }

        [JsonConstructor]
        public UpdateSpecialistDetails(Guid id, string title, string firstname, string surname, string email, string cellphone)
        {
            Id = id;
            Title = title;
            FirstName = firstname;
            Surname = surname;
            Email = email;
            Cellphone = cellphone;
        }
    }
}
