using MedPark.MedicalPractice.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Config
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<MedicalPracticeDbContext>())
                {
                    EnsureSeedData(context);
                }
            }
        }

        private static void EnsureSeedData(MedicalPracticeDbContext context)
        {
            Console.WriteLine("Seeding database...");

            Console.WriteLine("Schemes being populated");
            List<MedicalScheme> schemes = GetSchemes(new List<MedicalScheme>());
            foreach (var scheme in schemes)
            {
                if (context.MedicalScheme.Where(x => x.SchemeName == scheme.SchemeName).FirstOrDefault() == null)
                {
                    context.MedicalScheme.Add(scheme);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Learning institutes being populated");
            List<Institute> institutes = GetInstitutes(new List<Institute>());
            foreach (var institute in institutes)
            {
                if (context.Institute.Where(x => x.Name == institute.Name).FirstOrDefault() == null)
                {
                    context.Institute.Add(institute);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Specialities being populated");
            List<Speciality> specilities = GetSpecialities(new List<Speciality>());
            foreach (var specilitie in specilities)
            {
                if (context.Speciality.Where(x => x.Name == specilitie.Name).FirstOrDefault() == null)
                {
                    context.Speciality.Add(specilitie);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Medical Practices being populated");
            List<Practice> practices = GetMeddicalPractices(new List<Practice>());
            foreach (var practice in practices)
            {
                if (context.Practice.Where(x => x.PracticeName == practice.PracticeName).FirstOrDefault() == null)
                {
                    context.Practice.Add(practice);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Medical Registrations being populated");
            List<PendingRegistration> registrations = GetSeededRegistrations(new List<PendingRegistration>());
            foreach (var reg in registrations)
            {
                if (context.PendingRegistration.Where(x => x.Email.Contains(reg.Email)).FirstOrDefault() == null)
                {
                    context.PendingRegistration.Add(reg);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Appointment types");
            List<AppointmentType> appTypes = GetAppointmentTypes(new List<AppointmentType>());
            foreach (var app in appTypes)
            {
                if (context.AppointmentType.Where(x => x.Name == app.Name).FirstOrDefault() == null)
                {
                    context.AppointmentType.Add(app);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static List<MedicalScheme> GetSchemes(List<MedicalScheme> schemes)
        {
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Discovery Health" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Bestmed" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Bonitas" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Fedhealth" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Medihelp" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Momentum Health" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Profmed" });
            schemes.Add(new MedicalScheme (Guid.NewGuid()){ SchemeName = "Bankmed" });

            return schemes;
        }

        private static List<Institute> GetInstitutes(List<Institute> institutes)
        {
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "University of Pretoria" });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "University of Johannesburg" });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "University of Cape Town" });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "Wits University" });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "University of KwaZulu-Natal " });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "University of Limpopo" });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "University of Stellenbosch" });
            institutes.Add(new Institute (Guid.NewGuid()){ Name = "Nelson Mandela Metropolitan University" });

            return institutes;
        }

        public static List<Speciality> GetSpecialities(List<Speciality> specialities)
        {
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "General Practitioner" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Dentist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Therapeutic Reflexologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Aesthetic Practitioner" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Anaesthesiologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Anaesthetist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Audiologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Biokineticist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Biokinetics" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Cardiologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Chiropractor" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Clinical Haematologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Clinical Psychologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Counselling Psychologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Counsellor" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Dental Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Dental Therapist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Dermatologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Dietician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Dietician / Nutritionist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Doctor" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Ear, Nose &amp; Throat Specialist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Educational Psychologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Endocrinologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Family Physician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Family Practice" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Forensic Psychologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Gastroenterologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "General Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Gynaecologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "HIV Clinician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Haematology" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Homeopath" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Integrative Medicine Practitioner" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Interventional Radiologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Marriage Counsellor" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Maxillofacial Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Medical Oncologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Medical Technologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Neurologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Neurosurgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Nurse" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Obstetrician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Obstetrics And Gynaecologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Occupational Therapist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Oncologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Ophthalmologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Optometrist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Oral Hygienist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Orthodontist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Orthopaedic Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Orthotist & Prosthetist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Otolaryngologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Paediatric Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Paediatrician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Periodontist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Pharmacy" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Physician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Physiotherapist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Plastic Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Podiatrist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Prosthodontist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Psychiatrist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Psychologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Pulmonologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Radiation Oncologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Radiologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Reflexologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Rheumatologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Sexologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Shoulder and Elbow Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Social Psychologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Social Worker" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Sonographer" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Specialist Family Physician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Specialist Physician" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Sport Medicine Practitioner" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Sport Physiologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Sport Physiotherapist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Sports Medicine" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Thoracic Surgeon" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Travel Doctor" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Urologist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Visual Therapist" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Wellness Counsellor" });
            specialities.Add(new Speciality (Guid.NewGuid()){ Name = "Wellness Practitioner" });

            return specialities;
        }

        public static List<Practice> GetMeddicalPractices(List<Practice> practices)
        {
            practices.Add(new Practice (Guid.NewGuid()){ PracticeName = "Menlo Park Day to Day Medical House" });
            //practices.Add(new Practice (Guid.NewGuid()){ PracticeName = "" });

            return practices;
        }

        public static List<PendingRegistration> GetSeededRegistrations(List<PendingRegistration> regs)
        {
            regs.Add(new PendingRegistration (Guid.NewGuid()) { Email = "@Test.com", FirstName = "Gerade", LastName = "Geldenhuys", Mobile = "+27828789615", PracticeId = Guid.Parse("D83539F7-0919-40C1-BF69-4F99BF8DB13F"), IsAdmin = true, OTP = "147852" });

            return regs;
        }

        private static List<AppointmentType> GetAppointmentTypes(List<AppointmentType> types)
        {
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Annual Physical" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Birth Control/Contraception" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Ear Infection" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Ear Syringe" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Flu/Cough/Sinus" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "General Consultation" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "General Follow Up" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "High Blood Pressure" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Hip/Back/Neck Pain" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Illness" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Injury" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Insurance Medical" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Minor procedure" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Muscle Strain" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Other" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Pap Smear" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Pre-Surgery Screening" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Prescription/Refill" });
            types.Add(new AppointmentType(Guid.NewGuid()) { Name = "Vaccine(s)/Flu Shot" });

            return types;
        }
    }
}
