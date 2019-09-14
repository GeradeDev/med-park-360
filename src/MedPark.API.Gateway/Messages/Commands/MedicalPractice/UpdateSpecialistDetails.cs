using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands
{
    [MessageNamespace("medical-practice")]
    public class UpdateSpecialistDetails : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }

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
