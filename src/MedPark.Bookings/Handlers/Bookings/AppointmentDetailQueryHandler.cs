using AutoMapper;
using MedPark.Bookings.Domain;
using MedPark.Bookings.Dto;
using MedPark.Bookings.Model.MedicalPracticeService;
using MedPark.Bookings.Queries;
using MedPark.Bookings.Services;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.Bookings
{
    public class AppointmentDetailQueryHandler : IQueryHandler<AppointmentDetailQuery, AppointmentDetailDto>
    {
        private IMedParkRepository<Appointment> _appRepo { get; }
        private IMedParkRepository<Specialist> _specialistRepo { get; }

        private IMapper _mapper { get; }

        private ISpecialistService _specialistServ { get; }

        public AppointmentDetailQueryHandler(IMedParkRepository<Appointment> appRepo, IMapper mapper, IMedParkRepository<Specialist> specialistRepo, ISpecialistService specialistServ)
        {
            _appRepo = appRepo;
            _specialistRepo = specialistRepo;
            _mapper = mapper;
            _specialistServ = specialistServ;
        }

        public async Task<AppointmentDetailDto> HandleAsync(AppointmentDetailQuery query)
        {
            AppointmentDetailDto result = new AppointmentDetailDto();

            Appointment app = await _appRepo.GetAsync(query.AppointmentId);

            if (app is null)
                throw new MedParkException("appointment_not_exist", $"The appointment {query.AppointmentId} does not exist.");

            Specialist specialist = await _specialistRepo.GetAsync(app.SpecialistId);

            if (specialist is null)
                throw new MedParkException("specialist_not_exist", $"The specialist {app.SpecialistId} does not exist.");


            PracticeDto practDetails = await _specialistServ.GetPracticeDetails(specialist.PracticeId);
            PracticeAddressDTO practiceAddr = await _specialistServ.GetSpecialistAddress(specialist.PracticeId);
            SpecialistAppointmentTypesDTO appType = await _specialistServ.GetAppointmentTypeDetails(app.AppointmentType);

            result = _mapper.Map<AppointmentDetailDto>(app);

            result.Practice = practDetails;
            result.Address = practiceAddr;
            result.SpecialistName = specialist.FirstName + " " + specialist.Surname;
            result.SpecialistTitle = specialist.Title;

            result.AppointmentType = (appType.TypesLinkedToSpecilaist.Count > 0 ? appType.TypesLinkedToSpecilaist.FirstOrDefault().Name : "");

            //Get Medcical scheme details for appointment
            AcceptedMedicalSchemeDTO scheme;
            if (app.HasMedicalAid)
            {
                scheme = await _specialistServ.GetSchemeById(app.MedicalScheme.Value);

                result.MedicalScheme = scheme.SchemeName;
                result.MedicalAidMembershipNo = app.MedicalAidMembershipNo;
            }

            return result;
        }
    }
}
