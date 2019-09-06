using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Dto
{
    public class OperatingHoursDTO
    {
        public Guid Id { get; set; }
        public Guid PracticeId { get; set; }
        public Guid SpecialistId { get; set; }
        public TimeSpan? SundayOpen { get; set; }
        public TimeSpan? SundayClose { get; set; }
        public TimeSpan? MondayOpen { get; set; }
        public TimeSpan? MondayClose { get; set; }
        public TimeSpan? TuesdayOpen { get; set; }
        public TimeSpan? TuesdayClose { get; set; }
        public TimeSpan? WednesdayOpen { get; set; }
        public TimeSpan? WednesdayClose { get; set; }
        public TimeSpan? ThursdayOpen { get; set; }
        public TimeSpan? ThursdayClose { get; set; }
        public TimeSpan? FridayOpen { get; set; }
        public TimeSpan? FridayClose { get; set; }
        public TimeSpan? SaturdayOpen { get; set; }
        public TimeSpan? SaturdayClose { get; set; }
        public TimeSpan? PublicHolidayOpen { get; set; }
        public TimeSpan? PublicHolidayClose { get; set; }
    }
}
