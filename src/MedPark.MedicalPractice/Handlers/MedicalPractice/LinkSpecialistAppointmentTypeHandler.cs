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
    public class LinkSpecialistAppointmentTypeHandler : ICommandHandler<LinkSpecialistAppointmentType>
    {
        private IMedParkRepository<AppointmentType> _appointmentTypeRepo;
        private IMedParkRepository<AppointmentAccepted> _acceptedAppointmentTypeRepo;
        private IMedParkRepository<Specialist> _specialistRepo;

        public LinkSpecialistAppointmentTypeHandler(IMedParkRepository<AppointmentType> appointmentTypeRepo, IMedParkRepository<AppointmentAccepted> acceptedAppointmentTypeRepo, IMedParkRepository<Specialist> specialistRepo)
        {
            _appointmentTypeRepo = appointmentTypeRepo;
            _acceptedAppointmentTypeRepo = acceptedAppointmentTypeRepo;
            _specialistRepo = specialistRepo;
        }

        public async Task HandleAsync(LinkSpecialistAppointmentType command, ICorrelationContext context)
        {
            Specialist specialist = await _specialistRepo.GetAsync(command.SpecialistId);
            if (specialist is null)
                throw new MedParkException("specialist_does_not_Exist", $"The specialist {command.SpecialistId} does not exists.");


            AppointmentType appType = await _appointmentTypeRepo.GetAsync(command.AppointmentTypeId);
            if (appType is null)
                throw new MedParkException("appointment_type_does_not_Exist", $"The appointment type {command.AppointmentTypeId} does not exists.");


            AppointmentAccepted appointmentLink = await _acceptedAppointmentTypeRepo.GetAsync(x => x.SpecialistId == command.SpecialistId && x.AppointmentTypeId == command.AppointmentTypeId);
            if (appointmentLink != null)
                throw new MedParkException("link_already_Exist", $"The specialist {command.SpecialistId} is already linked to appointment type {command.AppointmentTypeId}.");


            AppointmentAccepted newLink = new AppointmentAccepted(Guid.NewGuid());
            newLink.Enabled = true;
            newLink.SpecialistId = command.SpecialistId;
            newLink.AppointmentTypeId = command.AppointmentTypeId;

            newLink.Use();

            await _acceptedAppointmentTypeRepo.AddAsync(newLink);
        }
    }
}
