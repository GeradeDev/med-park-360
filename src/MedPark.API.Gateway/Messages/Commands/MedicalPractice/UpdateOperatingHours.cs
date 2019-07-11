using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands
{
    [MessageNamespace("medical-practice")]
    public class UpdateOperatingHours : ICommand
    {
        public Guid Id { get; protected set; }

        public DateTime? SundayOpen { get; set; }
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

        [JsonConstructor]
        public UpdateOperatingHours(Guid id, DateTime? sundayOpen, DateTime? sundayClose, DateTime? mondayOpen, DateTime? mondayClose, DateTime? tuesdayOpen, DateTime? tuesdayClose, DateTime? wednesdayOpen, DateTime? wednesdayClose, DateTime? thursdayOpen, DateTime? thursdayClose, DateTime? fridayOpen, DateTime? fridayClose, DateTime? saturdayOpen, DateTime? saturdayClose, DateTime? publicHolidayOpen, DateTime? publicHolidayClose)
        {
            Id = id;
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
        }
    }
}
