﻿using MedPark.Common.Types;
using MedPark.MedicalPractice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Queries
{
    public class SpecialistQualificationsQuery : IQuery<SpecialistQualificationDTO>
    {
        public Guid SpecialistId { get; set; }
    }
}
