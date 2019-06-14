using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class OperatingHours : IIdentifiable
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Guid PracticeId { get; set; }

        public DateTime? SundayOpen { get;  set; }
        public DateTime? SundayClose { get; set; }
        public DateTime? MondayOpen { get; set; }
        public DateTime? MondayClose { get; set; }
        public DateTime? TuesdayOpen { get; set; }
        public DateTime? TuesdayClose { get; set; }
        public DateTime? WednesdayOpen { get; set; }
        public DateTime? WednesdayClose { get; set; }
        public DateTime? ThursdayOpen { get; set; }
        public DateTime? ThursdayClose { get; set; }
        public DateTime? FridayOpen { get; set; }
        public DateTime? FridayClose { get; set; }
        public DateTime? SaturdayOpen { get; set; }
        public DateTime? SaturdayClose { get; set; }

        public DateTime? PublicHolidayOpen { get; set; }
        public DateTime? PublicHolidayClose { get; set; }
    }
}
