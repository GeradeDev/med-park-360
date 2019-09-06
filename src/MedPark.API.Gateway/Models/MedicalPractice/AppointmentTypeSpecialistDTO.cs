﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Models.MedicalPractice
{
    public class AppointmentTypeSpecialistDTO
    {
        public Guid AppointmentTypeId { get; set; }
        public string AppointmentTypeName { get; set; }
        public List<SpecialistDetailDTO> Specilists { get; set; }

        public AppointmentTypeSpecialistDTO()
        {
            Specilists = new List<SpecialistDetailDTO>();
        }
    }
}
