using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class Speciality : BaseIdentifiable
    {
        public Speciality(Guid id) : base(id)
        {

        }

        public string Name { get; set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}
