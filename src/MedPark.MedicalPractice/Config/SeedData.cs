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

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static List<MedicalScheme> GetSchemes(List<MedicalScheme> schemes)
        {
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Discovery Health" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Bestmed" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Bonitas" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Fedhealth" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Medihelp" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Momentum Health" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Profmed" });
            schemes.Add(new MedicalScheme { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, SchemeName = "Bankmed" });

            return schemes;
        }

        private static List<Institute> GetInstitutes(List<Institute> institutes)
        {
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "University of Pretoria" });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "University of Johannesburg" });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "University of Cape Town" });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Wits University" });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "University of KwaZulu-Natal " });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "University of Limpopo" });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "University of Stellenbosch" });
            institutes.Add(new Institute { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Nelson Mandela Metropolitan University" });

            return institutes;
        }

        public static List<Speciality> GetSpecialities(List<Speciality> specialities)
        {
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "General Practitioner" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Dentist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Therapeutic Reflexologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Aesthetic Practitioner" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Anaesthesiologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Anaesthetist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Audiologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Biokineticist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Biokinetics" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Cardiologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Chiropractor" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Clinical Haematologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Clinical Psychologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Counselling Psychologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Counsellor" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Dental Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Dental Therapist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Dermatologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Dietician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Dietician / Nutritionist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Doctor" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Ear, Nose &amp; Throat Specialist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Educational Psychologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Endocrinologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Family Physician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Family Practice" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Forensic Psychologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Gastroenterologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "General Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Gynaecologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "HIV Clinician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Haematology" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Homeopath" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Integrative Medicine Practitioner" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Interventional Radiologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Marriage Counsellor" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Maxillofacial Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Medical Oncologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Medical Technologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Neurologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Neurosurgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Nurse" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Obstetrician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Obstetrics And Gynaecologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Occupational Therapist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Oncologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Ophthalmologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Optometrist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Oral Hygienist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Orthodontist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Orthopaedic Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Orthotist & Prosthetist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Otolaryngologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Paediatric Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Paediatrician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Periodontist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Pharmacy" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Physician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Physiotherapist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Plastic Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Podiatrist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Prosthodontist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Psychiatrist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Psychologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Pulmonologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Radiation Oncologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Radiologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Reflexologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Rheumatologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Sexologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Shoulder and Elbow Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Social Psychologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Social Worker" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Sonographer" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Specialist Family Physician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Specialist Physician" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Sport Medicine Practitioner" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Sport Physiologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Sport Physiotherapist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Sports Medicine" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Thoracic Surgeon" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Travel Doctor" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Urologist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Visual Therapist" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Wellness Counsellor" });
            specialities.Add(new Speciality { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, Name = "Wellness Practitioner" });

            return specialities;
        }

        public static List<Practice> GetMeddicalPractices(List<Practice> practices)
        {
            practices.Add(new Practice { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, PracticeName = "Menlo Park Day to Day Medical House" });
            //practices.Add(new Practice { Id = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, PracticeName = "" });

            return practices;
        }
    }
}
