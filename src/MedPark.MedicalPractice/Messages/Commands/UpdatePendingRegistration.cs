using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class UpdatePendingRegistration : ICommand
    {
        public Guid Id { get; }
        public String FirstName { get; }
        public String LastName { get; }
        public String Email { get; }
        public String Mobile { get; }
        public Guid PracticeId { get; }
        public Boolean IsAdmin { get; }

        [JsonConstructor]
        public UpdatePendingRegistration(Guid id, string firstName, string lastName, string email, string mobile, Guid practiceId, Boolean isAdmin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
            PracticeId = practiceId;
            IsAdmin = isAdmin;
        }
    }
}
