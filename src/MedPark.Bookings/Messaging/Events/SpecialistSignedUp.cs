using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Messages.Events
{
    [MessageNamespace("identity")]
    public class SpecialistSignedUp : IEvent
    {
        public Guid Id { get; }
        public string FirstName { get;}
        public string Surname { get; }
        public string Email { get; }
        public Guid PracticeId { get; }

        [JsonConstructor]
        public SpecialistSignedUp(Guid id, string firstName, string surname, string email, Guid practiceid)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Email = email;
            PracticeId = practiceid;
        }
    }
}
