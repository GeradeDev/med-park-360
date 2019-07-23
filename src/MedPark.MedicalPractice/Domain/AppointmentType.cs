using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class AppointmentType : BaseIdentifiable
    {
        public AppointmentType(Guid Id) : base(Id)
        {

        }

        public string Name { get; set; }
    }
}
