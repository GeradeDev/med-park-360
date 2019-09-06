using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Models.MedicalPractice
{
    public class AppointmentTimesForDay
    {
        public string DayOfWeek { get; set; }
        public List<TimeSpan> AvailableTimes { get; set; }

        public AppointmentTimesForDay()
        {
            AvailableTimes = new List<TimeSpan>();
        }
    }
}
