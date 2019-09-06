using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class OperatingHoursDetailQueryHandler : IQueryHandler<OperatingHoursDetailQuery, OperatingHoursDetailDTO>
    {
        private IMedParkRepository<Practice> _practiceRepo { get; }
        private IMedParkRepository<OperatingHours> _hoursRepo { get; }
        private IMedParkRepository<Specialist> _specialistRepo { get; }
        private IMapper _mapper { get; }

        public OperatingHoursDetailQueryHandler(IMedParkRepository<Practice> practiceRepo, IMedParkRepository<OperatingHours> hoursRepo, IMedParkRepository<Specialist> specialistRepo, IMapper mapper)
        {
            _practiceRepo = practiceRepo;
            _hoursRepo = hoursRepo;
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<OperatingHoursDetailDTO> HandleAsync(OperatingHoursDetailQuery query)
        {
            OperatingHoursDetailDTO result = new OperatingHoursDetailDTO();

            if (query.SpecialistId != Guid.Empty)
            {
                Specialist s = await _specialistRepo.GetAsync(query.SpecialistId.Value);

                OperatingHours sop = await _hoursRepo.GetAsync(x => x.SpecialistId == s.Id);

                result.AppointmentDuration = s.AppointmentDuration;
                result.PracticeOperatingHours = _mapper.Map<OperatingHoursDTO>(sop);

                var days = new List<DayOfWeek>();
                days.Add(DateTime.Now.DayOfWeek);
                days.Add(DateTime.Now.AddDays(1).DayOfWeek);

                DateTime.Now.GetWeekDays().ForEach(d =>
                {
                    if (d == DayOfWeek.Sunday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.SundayOpen.Value, sop.SundayClose.Value, d, s.AppointmentDuration));
                    }
                    else if (d == DayOfWeek.Monday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.MondayOpen.Value, sop.MondayClose.Value, d, s.AppointmentDuration));
                    }
                    else if (d == DayOfWeek.Tuesday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.TuesdayOpen.Value, sop.TuesdayClose.Value, d, s.AppointmentDuration));
                    }
                    else if (d == DayOfWeek.Wednesday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.WednesdayOpen.Value, sop.WednesdayClose.Value, d, s.AppointmentDuration));
                    }
                    else if (d == DayOfWeek.Thursday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.ThursdayOpen.Value, sop.ThursdayClose.Value, d, s.AppointmentDuration));
                    }
                    else if (d == DayOfWeek.Friday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.FridayOpen.Value, sop.FridayClose.Value, d, s.AppointmentDuration));
                    }
                    else if (d == DayOfWeek.Saturday)
                    {
                        result.AppointmentTimes.Add(GetAvailableHours(sop.SaturdayOpen.Value, sop.SaturdayClose.Value, d, s.AppointmentDuration));
                    }
                });
            }
            else
            {

            }
            
            return result;
        }

        public AppointmentTimesForDay GetAvailableHours(TimeSpan openTime, TimeSpan closingTime, DayOfWeek day, TimeSpan appDuration)
        {
            AppointmentTimesForDay times = new AppointmentTimesForDay();
            times.DayOfWeek = day.ToString();

            DateTime appTime = (day == DateTime.Today.DayOfWeek ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, openTime.Hours, openTime.Minutes, openTime.Seconds) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, openTime.Hours, openTime.Minutes, openTime.Seconds));

            while ((appTime.TimeOfDay + appDuration) < closingTime)
            {
                appTime = (appTime + appDuration);
                times.AvailableTimes.Add(appTime.TimeOfDay);
            }

            return times;
        }
    }
}
