using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class AddOperatingHours : ICommand
    {
        public Guid Id { get; protected set; }
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

        [JsonConstructor]
        public AddOperatingHours(Guid id, Guid practiceId, TimeSpan? sundayOpen, TimeSpan? sundayClose, TimeSpan? mondayOpen, TimeSpan? mondayClose, TimeSpan? tuesdayOpen, TimeSpan? tuesdayClose, TimeSpan? wednesdayOpen, TimeSpan? wednesdayClose, TimeSpan? thursdayOpen, TimeSpan? thursdayClose, TimeSpan? fridayOpen, TimeSpan? fridayClose, TimeSpan? saturdayOpen, TimeSpan? saturdayClose, TimeSpan? publicHolidayOpen, TimeSpan? publicHolidayClose, Guid specialistId)
        {
            Id = id;
            PracticeId = practiceId;
            SundayOpen = sundayOpen;
            SundayClose = sundayClose;
            MondayClose = mondayClose;
            MondayOpen = mondayOpen;
            TuesdayOpen = tuesdayOpen;
            TuesdayClose = tuesdayClose;
            WednesdayOpen = wednesdayOpen;
            WednesdayClose = wednesdayClose;
            ThursdayOpen = thursdayOpen;
            ThursdayClose = thursdayClose;
            FridayOpen = fridayOpen;
            FridayClose = fridayClose;
            SaturdayOpen = saturdayOpen;
            SaturdayClose = saturdayClose;
            PublicHolidayOpen = publicHolidayOpen;
            PublicHolidayClose = publicHolidayClose;
            SpecialistId = specialistId;
        }
    }
}
