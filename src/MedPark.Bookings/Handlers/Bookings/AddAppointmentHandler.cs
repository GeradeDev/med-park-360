using MedPark.Bookings.Domain;
using MedPark.Bookings.Messaging.Command;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.Bookings
{
    public class AddAppointmentHandler : ICommandHandler<AddAppointment>
    {
        private IMedParkRepository<Appointment> _appRepo { get; set; }
        private IMedParkRepository<Customer> _customerRepo { get; set; }
        private IMedParkRepository<Specialist> _specialistRepo { get; set; }

        public AddAppointmentHandler(IMedParkRepository<Appointment> appRepo, IMedParkRepository<Customer> customerRepo, IMedParkRepository<Specialist> specialistRepo)
        {
            _appRepo = appRepo;
            _customerRepo = customerRepo;
            _specialistRepo = specialistRepo;
        }

        public async Task HandleAsync(AddAppointment command, ICorrelationContext context)
        {
            Customer patient = await _customerRepo.GetAsync(command.PatientId);

            //Does custoemr exist
            if (patient is null)
                throw new MedParkException("add_appointment_customer_does_not_exist", $"Customer {command.PatientId} does not exists.");

            Specialist specialist = await _specialistRepo.GetAsync(command.SpecialistId);

            //Does specialist exist
            if (specialist is null)
                throw new MedParkException("add_appointment_specialist_does_not_exist", $"Specialist {command.SpecialistId} does not exists.");

            //Create a new appointment
            Appointment newAppointment = new Appointment(command.AppointmentId);
            newAppointment.SetAppointmentDetails(command.AppointmentType, command.ScheduledDate, command.IsPostponement);

            //Set the pateint details for the appointment
            newAppointment.SetPatientDetails(patient.FirstName, patient.LastName, patient.Mobile, patient.Email, patient.Id);

            if (command.MedicalScheme.HasValue)
                newAppointment.SetMedicalScheme(command.MedicalScheme.Value, command.MedicalAidMembershipNo);

            //Set the specialist details for the sappointment
            newAppointment.SetSpecialistDetails(specialist.Title, (specialist.FirstName[0] + " " + specialist.Surname[0]).GetInitials(), specialist.Surname, specialist.Cellphone, specialist.Email, specialist.Id);

            //Set Comment
            newAppointment.SetComment(command.Comment);


            //Validate before saving
            newAppointment.Use();
            await _appRepo.AddAsync(newAppointment);
        }
    }
}
