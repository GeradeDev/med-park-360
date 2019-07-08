﻿using MedPark.MedicalPractice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Dto
{
    public class PracticeDetailDTO
    {
        public PracticeDto Practice { get; set; }
        public List<PracticeAddressDTO> Addresses { get; set; }
        public List<SpecialistDto> Specialists { get; set; }
        public OperatingHoursDTO OperatingHours { get; set; }

        public PracticeDetailDTO()
        {
            Addresses = new List<PracticeAddressDTO>();
            Specialists = new List<SpecialistDto>();
        }
    }
}
