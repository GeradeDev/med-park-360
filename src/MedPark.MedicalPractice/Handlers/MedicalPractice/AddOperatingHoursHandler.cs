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
    public class AddOperatingHoursHandler : ICommandHandler<AddOperatingHours>
    {
        private IMedParkRepository<OperatingHours> _hoursRepo { get; }

        public AddOperatingHoursHandler(IMedParkRepository<OperatingHours> hoursRepo)
        {
            _hoursRepo = hoursRepo;
        }

        public async Task HandleAsync(AddOperatingHours command, ICorrelationContext context)
        {
            try
            {
                OperatingHours practiceHours = await _hoursRepo.GetAsync(x => x.PracticeId == command.PracticeId && x.SpecialistId == command.SpecialistId);

                if (practiceHours != null)
                    throw new MedParkException("practice_operating_hours_already_exists", $"The operating hours for practice {command.PracticeId} already exists.");

                practiceHours = new OperatingHours(command.Id)
                {
                    SundayOpen = command.SundayOpen,
                    SundayClose = command.SundayClose,
                    MondayOpen = command.MondayOpen,
                    MondayClose = command.MondayClose,
                    TuesdayOpen = command.TuesdayOpen,
                    TuesdayClose = command.TuesdayClose,
                    WednesdayOpen = command.WednesdayOpen,
                    WednesdayClose = command.WednesdayClose,
                    ThursdayOpen = command.ThursdayOpen,
                    ThursdayClose = command.ThursdayClose,
                    FridayOpen = command.FridayOpen,
                    FridayClose = command.FridayClose,
                    SaturdayOpen = command.SaturdayOpen,
                    SaturdayClose = command.SaturdayClose,
                    PublicHolidayOpen = command.PublicHolidayOpen,
                    PublicHolidayClose = command.PublicHolidayClose,
                    PracticeId = command.PracticeId,
                    SpecialistId = command.SpecialistId
                };

                await _hoursRepo.AddAsync(practiceHours);

            }
            catch (Exception ex) { }
        }
    }
}
