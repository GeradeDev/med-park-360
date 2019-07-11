using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class UpdateOperatingHoursHandler : ICommandHandler<UpdateOperatingHours>
    {
        private IMedParkRepository<OperatingHours> _hoursRepo { get; }

        public UpdateOperatingHoursHandler(IMedParkRepository<OperatingHours> hoursRepo)
        {
            _hoursRepo = hoursRepo;

        }

        public async Task HandleAsync(UpdateOperatingHours command, ICorrelationContext context)
        {
            OperatingHours practiceHours = await _hoursRepo.GetAsync(x => x.Id == command.Id);
            if (practiceHours == null)
                throw new MedParkException("practice_operating_hours_does_not_exists", $"The practice operating hours {command.Id} does not exist exists.");

            practiceHours.SundayOpen = command.SundayOpen;
            practiceHours.SundayClose = command.SundayClose;
            practiceHours.MondayOpen = command.MondayOpen;
            practiceHours.MondayClose = command.MondayClose;
            practiceHours.TuesdayOpen = command.TuesdayOpen;
            practiceHours.TuesdayClose = command.TuesdayClose;
            practiceHours.WednesdayOpen = command.WednesdayOpen;
            practiceHours.WednesdayClose = command.WednesdayClose;
            practiceHours.ThursdayOpen = command.ThursdayOpen;
            practiceHours.ThursdayClose = command.ThursdayClose;
            practiceHours.FridayOpen = command.FridayOpen;
            practiceHours.FridayClose = command.FridayClose;
            practiceHours.SaturdayOpen = command.SaturdayOpen;
            practiceHours.SaturdayClose = command.SaturdayClose;
            practiceHours.PublicHolidayOpen = command.PublicHolidayOpen;
            practiceHours.PublicHolidayClose = command.PublicHolidayClose;

            practiceHours.UpdatedModifiedDate();

            await _hoursRepo.UpdateAsync(practiceHours);
        }
    }
}
