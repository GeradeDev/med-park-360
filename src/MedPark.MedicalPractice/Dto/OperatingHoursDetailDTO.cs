﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Dto
{
    public class OperatingHoursDetailDTO
    {
        public TimeSpan AppointmentDuration { get; set; }
        public OperatingHoursDTO PracticeOperatingHours { get; set; }
        public List<AppointmentTimesForDay> AppointmentTimes { get; set; }

        public OperatingHoursDetailDTO()
        {
            AppointmentTimes = new List<AppointmentTimesForDay>();
        }
    }
}
