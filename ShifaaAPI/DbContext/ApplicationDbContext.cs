using ShifaaAPI.Enums;
using ShifaaAPI.Models;
using ShifaaAPI.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<PatientFavoriteDoctors> PatientFavoriteDoctors { get; set; }
        public DbSet<AvailableAppointments> AvailableAppointments { get; set; }
        public DbSet<Chat> Chats { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.NoAction); // Change to NoAction or Restrict

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorId)
                .OnDelete(DeleteBehavior.NoAction); // Change to NoAction or Restrict

            // Booking Relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Appointment)
                .WithMany()
                .HasForeignKey(b => b.AppointmentId);

            modelBuilder.Entity<Review>()
               .HasOne(b => b.Patient)
               .WithMany(p => p.Reviews)
               .HasForeignKey(b => b.PatientId)
               .OnDelete(DeleteBehavior.NoAction); // Change to NoAction or Restrict

            modelBuilder.Entity<PatientFavoriteDoctors>()
                .HasKey(pfd => new { pfd.PatientId, pfd.DoctorId });

            modelBuilder.Entity<PatientFavoriteDoctors>()
                .HasOne(p => p.patient)
                .WithMany(d => d.PatientFavoriteDoctors)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete for Patient

            modelBuilder.Entity<PatientFavoriteDoctors>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.PatientFavoriteDoctors)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete for Doctor

            modelBuilder.Entity<Doctor>()
            .HasMany(d => d.AvailableAppointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<AvailableAppointments>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.AvailableAppointments)
            .HasForeignKey(a => a.DoctorId);


            // Seed Users for Doctors
            modelBuilder.Entity<User>().HasData(
                  new User
                  {
                      Id = 1,
                      Name = "Dr. John Smith",
                      Email = "john.smith@hospital.com",
                      UserName = "dr.john.smith",
                      Password = "hashed_password_123",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 2,
                      Name = "Dr. Sarah Johnson",
                      Email = "sarah.johnson@hospital.com",
                      UserName = "dr.sarah.johnson",
                      Password = "hashed_password_456",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 3,
                      Name = "Dr. Ahmed Ali",
                      Email = "ahmed.ali@hospital.com",
                      UserName = "dr.ahmed.ali",
                      Password = "hashed_password_789",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 4,
                      Name = "Dr. Emily Brown",
                      Email = "emily.brown@hospital.com",
                      UserName = "dr.emily.brown",
                      Password = "hashed_password_101",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 5,
                      Name = "Dr. William Davis",
                      Email = "william.davis@hospital.com",
                      UserName = "dr.william.davis",
                      Password = "hashed_password_102",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 6,
                      Name = "Dr. Fatima Hassan",
                      Email = "fatima.hassan@hospital.com",
                      UserName = "dr.fatima.hassan",
                      Password = "hashed_password_103",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 7,
                      Name = "Dr. Jacob Wilson",
                      Email = "jacob.wilson@hospital.com",
                      UserName = "dr.jacob.wilson",
                      Password = "hashed_password_104",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 8,
                      Name = "Dr. Sophia Martinez",
                      Email = "sophia.martinez@hospital.com",
                      UserName = "dr.sophia.martinez",
                      Password = "hashed_password_105",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 9,
                      Name = "Dr. Ethan Thompson",
                      Email = "ethan.thompson@hospital.com",
                      UserName = "dr.ethan.thompson",
                      Password = "hashed_password_106",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 10,
                      Name = "Dr. Ava Garcia",
                      Email = "ava.garcia@hospital.com",
                      UserName = "dr.ava.garcia",
                      Password = "hashed_password_107",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 11,
                      Name = "Dr. Michael Lee",
                      Email = "michael.lee@hospital.com",
                      UserName = "dr.michael.lee",
                      Password = "hashed_password_108",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 12,
                      Name = "Dr. Olivia Rodriguez",
                      Email = "olivia.rodriguez@hospital.com",
                      UserName = "dr.olivia.rodriguez",
                      Password = "hashed_password_109",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 13,
                      Name = "Dr. Benjamin White",
                      Email = "benjamin.white@hospital.com",
                      UserName = "dr.benjamin.white",
                      Password = "hashed_password_110",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 14,
                      Name = "Dr. Isabella Hall",
                      Email = "isabella.hall@hospital.com",
                      UserName = "dr.isabella.hall",
                      Password = "hashed_password_111",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 15,
                      Name = "Dr. Daniel Young",
                      Email = "daniel.young@hospital.com",
                      UserName = "dr.daniel.young",
                      Password = "hashed_password_112",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 16,
                      Name = "Dr. Mia King",
                      Email = "mia.king@hospital.com",
                      UserName = "dr.mia.king",
                      Password = "hashed_password_113",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 17,
                      Name = "Dr. James Wright",
                      Email = "james.wright@hospital.com",
                      UserName = "dr.james.wright",
                      Password = "hashed_password_114",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 18,
                      Name = "Dr. Amelia Scott",
                      Email = "amelia.scott@hospital.com",
                      UserName = "dr.amelia.scott",
                      Password = "hashed_password_115",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 19,
                      Name = "Dr. Lucas Green",
                      Email = "lucas.green@hospital.com",
                      UserName = "dr.lucas.green",
                      Password = "hashed_password_116",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 20,
                      Name = "Dr. Charlotte Adams",
                      Email = "charlotte.adams@hospital.com",
                      UserName = "dr.charlotte.adams",
                      Password = "hashed_password_117",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 21,
                      Name = "Dr. Henry Baker",
                      Email = "henry.baker@hospital.com",
                      UserName = "dr.henry.baker",
                      Password = "hashed_password_118",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 22,
                      Name = "Dr. Grace Nelson",
                      Email = "grace.nelson@hospital.com",
                      UserName = "dr.grace.nelson",
                      Password = "hashed_password_119",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 23,
                      Name = "Dr. Elijah Carter",
                      Email = "elijah.carter@hospital.com",
                      UserName = "dr.elijah.carter",
                      Password = "hashed_password_120",
                      EmailConfirmed = true
                  },
                  new User
                  {
                      Id = 24,
                      Name = "Dr. Lily Mitchell",
                      Email = "lily.mitchell@hospital.com",
                      UserName = "dr.lily.mitchell",
                      Password = "hashed_password_121",
                      EmailConfirmed = true
                  }
             );


            // Seed Specializations
            modelBuilder.Entity<Specialization>().HasData(
                  new Specialization { Id = 1, Name = "Cardiology" },
                  new Specialization { Id = 2, Name = "Dermatology" },
                  new Specialization { Id = 3, Name = "Neurology" },
                  new Specialization { Id = 4, Name = "Orthopedics" },
                  new Specialization { Id = 5, Name = "Pediatrics" },
                  new Specialization { Id = 6, Name = "Oncology" },
                  new Specialization { Id = 7, Name = "Psychiatry" },
                  new Specialization { Id = 8, Name = "Radiology" }
             );

            // Seed Doctors (Linked to Users and Specializations)
            modelBuilder.Entity<Doctor>().HasData(
                 // Doctors for Specialization: Cardiology (1)
                 new Doctor { Id = 1, Address = "123 Heart St", Gender = Gender.Male, Experience = "10 years", SpecializationId = 1 },
                 new Doctor { Id = 2, Address = "456 Pulse Ave", Gender = Gender.Female, Experience = "8 years", SpecializationId = 1 },
                 new Doctor { Id = 3, Address = "789 Artery Blvd", Gender = Gender.Male, Experience = "12 years", SpecializationId = 1 },

                 // Doctors for Specialization: Dermatology (2)
                 new Doctor { Id = 4, Address = "321 Skin Lane", Gender = Gender.Female, Experience = "7 years", SpecializationId = 2 },
                 new Doctor { Id = 5, Address = "654 Acne Dr", Gender = Gender.Male, Experience = "6 years", SpecializationId = 2 },
                 new Doctor { Id = 6, Address = "987 Derma Ct", Gender = Gender.Female, Experience = "9 years", SpecializationId = 2 },

                 // Doctors for Specialization: Neurology (3)
                 new Doctor { Id = 7, Address = "123 Brain Ave", Gender = Gender.Male, Experience = "15 years", SpecializationId = 3 },
                 new Doctor { Id = 8, Address = "456 Neuron Blvd", Gender = Gender.Female, Experience = "11 years", SpecializationId = 3 },
                 new Doctor { Id = 9, Address = "789 Spine Dr", Gender = Gender.Male, Experience = "13 years", SpecializationId = 3 },

                 // Doctors for Specialization: Orthopedics (4)
                 new Doctor { Id = 10, Address = "321 Bone St", Gender = Gender.Male, Experience = "14 years", SpecializationId = 4 },
                 new Doctor { Id = 11, Address = "654 Joint Ave", Gender = Gender.Female, Experience = "8 years", SpecializationId = 4 },
                 new Doctor { Id = 12, Address = "987 Fracture Rd", Gender = Gender.Male, Experience = "10 years", SpecializationId = 4 },

                 // Doctors for Specialization: Pediatrics (5)
                 new Doctor { Id = 13, Address = "123 Kids Ln", Gender = Gender.Female, Experience = "5 years", SpecializationId = 5 },
                 new Doctor { Id = 14, Address = "456 Baby Blvd", Gender = Gender.Male, Experience = "6 years", SpecializationId = 5 },
                 new Doctor { Id = 15, Address = "789 Child Ct", Gender = Gender.Female, Experience = "8 years", SpecializationId = 5 },

                 // Doctors for Specialization: Oncology (6)
                 new Doctor { Id = 16, Address = "321 Cancer St", Gender = Gender.Male, Experience = "12 years", SpecializationId = 6 },
                 new Doctor { Id = 17, Address = "654 Tumor Blvd", Gender = Gender.Female, Experience = "10 years", SpecializationId = 6 },
                 new Doctor { Id = 18, Address = "987 Chemo Rd", Gender = Gender.Male, Experience = "11 years", SpecializationId = 6 },

                 // Doctors for Specialization: Psychiatry (7)
                 new Doctor { Id = 19, Address = "123 Mind St", Gender = Gender.Female, Experience = "9 years", SpecializationId = 7 },
                 new Doctor { Id = 20, Address = "456 Emotion Ave", Gender = Gender.Male, Experience = "8 years", SpecializationId = 7 },
                 new Doctor { Id = 21, Address = "789 Therapy Ct", Gender = Gender.Female, Experience = "7 years", SpecializationId = 7 },

                 // Doctors for Specialization: Radiology (8)
                 new Doctor { Id = 22, Address = "321 Xray Ln", Gender = Gender.Male, Experience = "13 years", SpecializationId = 8 },
                 new Doctor { Id = 23, Address = "654 MRI Blvd", Gender = Gender.Female, Experience = "12 years", SpecializationId = 8 },
                 new Doctor { Id = 24, Address = "987 CT Scan Rd", Gender = Gender.Male, Experience = "14 years", SpecializationId = 8 }
            );


            //seed DoctorScheedule
            modelBuilder.Entity<DoctorSchedule>().HasData(
                // Schedules for Doctor 1
                new DoctorSchedule { Id = 1, Name = "Morning Shift", Date = new DateOnly(2024, 12, 16), TimeStart = new DateTime(2024, 12, 16, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 16, 12, 0, 0), Price = 100, DoctorId = 1 },
                new DoctorSchedule { Id = 2, Name = "Evening Shift", Date = new DateOnly(2024, 12, 16), TimeStart = new DateTime(2024, 12, 16, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 16, 19, 0, 0), Price = 120, DoctorId = 1 },

                // Schedules for Doctor 2
                new DoctorSchedule { Id = 3, Name = "Morning Shift", Date = new DateOnly(2024, 12, 17), TimeStart = new DateTime(2024, 12, 17, 8, 0, 0), TimeEnd = new DateTime(2024, 12, 17, 11, 0, 0), Price = 110, DoctorId = 2 },
                new DoctorSchedule { Id = 4, Name = "Evening Shift", Date = new DateOnly(2024, 12, 17), TimeStart = new DateTime(2024, 12, 17, 15, 0, 0), TimeEnd = new DateTime(2024, 12, 17, 18, 0, 0), Price = 130, DoctorId = 2 },

                // Schedules for Doctor 3
                new DoctorSchedule { Id = 5, Name = "Morning Shift", Date = new DateOnly(2024, 12, 18), TimeStart = new DateTime(2024, 12, 18, 10, 0, 0), TimeEnd = new DateTime(2024, 12, 18, 13, 0, 0), Price = 90, DoctorId = 3 },
                new DoctorSchedule { Id = 6, Name = "Evening Shift", Date = new DateOnly(2024, 12, 18), TimeStart = new DateTime(2024, 12, 18, 17, 0, 0), TimeEnd = new DateTime(2024, 12, 18, 20, 0, 0), Price = 150, DoctorId = 3 },

                // Schedules for Doctor 4
                new DoctorSchedule { Id = 7, Name = "Morning Shift", Date = new DateOnly(2024, 12, 19), TimeStart = new DateTime(2024, 12, 19, 8, 30, 0), TimeEnd = new DateTime(2024, 12, 19, 11, 30, 0), Price = 95, DoctorId = 4 },
                new DoctorSchedule { Id = 8, Name = "Evening Shift", Date = new DateOnly(2024, 12, 19), TimeStart = new DateTime(2024, 12, 19, 14, 30, 0), TimeEnd = new DateTime(2024, 12, 19, 17, 30, 0), Price = 125, DoctorId = 4 },

                // Schedules for Doctor 5
                new DoctorSchedule { Id = 9, Name = "Morning Shift", Date = new DateOnly(2024, 12, 20), TimeStart = new DateTime(2024, 12, 20, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 20, 12, 0, 0), Price = 110, DoctorId = 5 },
                new DoctorSchedule { Id = 10, Name = "Evening Shift", Date = new DateOnly(2024, 12, 20), TimeStart = new DateTime(2024, 12, 20, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 20, 19, 0, 0), Price = 140, DoctorId = 5 },

                // Schedules for Doctor 6
                new DoctorSchedule { Id = 11, Name = "Morning Shift", Date = new DateOnly(2024, 12, 21), TimeStart = new DateTime(2024, 12, 21, 8, 0, 0), TimeEnd = new DateTime(2024, 12, 21, 11, 0, 0), Price = 115, DoctorId = 6 },
                new DoctorSchedule { Id = 12, Name = "Evening Shift", Date = new DateOnly(2024, 12, 21), TimeStart = new DateTime(2024, 12, 21, 14, 0, 0), TimeEnd = new DateTime(2024, 12, 21, 17, 0, 0), Price = 125, DoctorId = 6 },

                // Schedules for Doctor 7
                new DoctorSchedule { Id = 13, Name = "Morning Shift", Date = new DateOnly(2024, 12, 22), TimeStart = new DateTime(2024, 12, 22, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 22, 12, 0, 0), Price = 105, DoctorId = 7 },
                new DoctorSchedule { Id = 14, Name = "Evening Shift", Date = new DateOnly(2024, 12, 22), TimeStart = new DateTime(2024, 12, 22, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 22, 19, 0, 0), Price = 135, DoctorId = 7 },

                // Schedules for Doctor 8
                new DoctorSchedule { Id = 15, Name = "Morning Shift", Date = new DateOnly(2024, 12, 23), TimeStart = new DateTime(2024, 12, 23, 9, 30, 0), TimeEnd = new DateTime(2024, 12, 23, 12, 30, 0), Price = 100, DoctorId = 8 },
                new DoctorSchedule { Id = 16, Name = "Evening Shift", Date = new DateOnly(2024, 12, 23), TimeStart = new DateTime(2024, 12, 23, 15, 30, 0), TimeEnd = new DateTime(2024, 12, 23, 18, 30, 0), Price = 120, DoctorId = 8 },

                // Schedules for Doctor 9
                new DoctorSchedule { Id = 17, Name = "Morning Shift", Date = new DateOnly(2024, 12, 24), TimeStart = new DateTime(2024, 12, 24, 8, 0, 0), TimeEnd = new DateTime(2024, 12, 24, 11, 0, 0), Price = 125, DoctorId = 9 },
                new DoctorSchedule { Id = 18, Name = "Evening Shift", Date = new DateOnly(2024, 12, 24), TimeStart = new DateTime(2024, 12, 24, 14, 30, 0), TimeEnd = new DateTime(2024, 12, 24, 17, 30, 0), Price = 135, DoctorId = 9 },

                // Schedules for Doctor 10
                new DoctorSchedule { Id = 19, Name = "Morning Shift", Date = new DateOnly(2024, 12, 25), TimeStart = new DateTime(2024, 12, 25, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 25, 12, 0, 0), Price = 110, DoctorId = 10 },
                new DoctorSchedule { Id = 20, Name = "Evening Shift", Date = new DateOnly(2024, 12, 25), TimeStart = new DateTime(2024, 12, 25, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 25, 19, 0, 0), Price = 130, DoctorId = 10 },

                // Schedules for Doctor 11
                new DoctorSchedule { Id = 21, Name = "Morning Shift", Date = new DateOnly(2024, 12, 26), TimeStart = new DateTime(2024, 12, 26, 8, 30, 0), TimeEnd = new DateTime(2024, 12, 26, 11, 30, 0), Price = 115, DoctorId = 11 },
                new DoctorSchedule { Id = 22, Name = "Evening Shift", Date = new DateOnly(2024, 12, 26), TimeStart = new DateTime(2024, 12, 26, 14, 30, 0), TimeEnd = new DateTime(2024, 12, 26, 17, 30, 0), Price = 125, DoctorId = 11 },

                // Schedules for Doctor 12
                new DoctorSchedule { Id = 23, Name = "Morning Shift", Date = new DateOnly(2024, 12, 27), TimeStart = new DateTime(2024, 12, 27, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 27, 12, 0, 0), Price = 120, DoctorId = 12 },
                new DoctorSchedule { Id = 24, Name = "Evening Shift", Date = new DateOnly(2024, 12, 27), TimeStart = new DateTime(2024, 12, 27, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 27, 19, 0, 0), Price = 140, DoctorId = 12 },

                // Repeat the same pattern for Doctors 13–24
                new DoctorSchedule { Id = 25, Name = "Morning Shift", Date = new DateOnly(2024, 12, 28), TimeStart = new DateTime(2024, 12, 28, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 28, 12, 0, 0), Price = 110, DoctorId = 13 },
                new DoctorSchedule { Id = 26, Name = "Evening Shift", Date = new DateOnly(2024, 12, 28), TimeStart = new DateTime(2024, 12, 28, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 28, 19, 0, 0), Price = 130, DoctorId = 13 },

                new DoctorSchedule { Id = 27, Name = "Morning Shift", Date = new DateOnly(2024, 12, 28), TimeStart = new DateTime(2024, 12, 28, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 28, 12, 0, 0), Price = 110, DoctorId = 14 },
                new DoctorSchedule { Id = 28, Name = "Evening Shift", Date = new DateOnly(2024, 12, 28), TimeStart = new DateTime(2024, 12, 28, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 28, 19, 0, 0), Price = 130, DoctorId = 14 },

                // Schedules for Doctor 15
                new DoctorSchedule { Id = 29, Name = "Morning Shift", Date = new DateOnly(2024, 12, 29), TimeStart = new DateTime(2024, 12, 29, 8, 30, 0), TimeEnd = new DateTime(2024, 12, 29, 11, 30, 0), Price = 115, DoctorId = 15 },
                new DoctorSchedule { Id = 30, Name = "Evening Shift", Date = new DateOnly(2024, 12, 29), TimeStart = new DateTime(2024, 12, 29, 14, 30, 0), TimeEnd = new DateTime(2024, 12, 29, 17, 30, 0), Price = 135, DoctorId = 15 },

                // Schedules for Doctor 16
                new DoctorSchedule { Id = 31, Name = "Morning Shift", Date = new DateOnly(2024, 12, 30), TimeStart = new DateTime(2024, 12, 30, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 30, 12, 0, 0), Price = 120, DoctorId = 16 },
                new DoctorSchedule { Id = 32, Name = "Evening Shift", Date = new DateOnly(2024, 12, 30), TimeStart = new DateTime(2024, 12, 30, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 30, 19, 0, 0), Price = 140, DoctorId = 16 },

                // Schedules for Doctor 17
                new DoctorSchedule { Id = 33, Name = "Morning Shift", Date = new DateOnly(2024, 12, 31), TimeStart = new DateTime(2024, 12, 31, 8, 0, 0), TimeEnd = new DateTime(2024, 12, 31, 11, 0, 0), Price = 110, DoctorId = 17 },
                new DoctorSchedule { Id = 34, Name = "Evening Shift", Date = new DateOnly(2024, 12, 31), TimeStart = new DateTime(2024, 12, 31, 14, 30, 0), TimeEnd = new DateTime(2024, 12, 31, 17, 30, 0), Price = 130, DoctorId = 17 },

                // Schedules for Doctor 18
                new DoctorSchedule { Id = 35, Name = "Morning Shift", Date = new DateOnly(2025, 01, 01), TimeStart = new DateTime(2025, 01, 01, 9, 0, 0), TimeEnd = new DateTime(2025, 01, 01, 12, 0, 0), Price = 125, DoctorId = 18 },
                new DoctorSchedule { Id = 36, Name = "Evening Shift", Date = new DateOnly(2025, 01, 01), TimeStart = new DateTime(2025, 01, 01, 16, 0, 0), TimeEnd = new DateTime(2025, 01, 01, 19, 0, 0), Price = 145, DoctorId = 18 },

                // Schedules for Doctor 19
                new DoctorSchedule { Id = 37, Name = "Morning Shift", Date = new DateOnly(2025, 01, 02), TimeStart = new DateTime(2025, 01, 02, 9, 30, 0), TimeEnd = new DateTime(2025, 01, 02, 12, 30, 0), Price = 115, DoctorId = 19 },
                new DoctorSchedule { Id = 38, Name = "Evening Shift", Date = new DateOnly(2025, 01, 02), TimeStart = new DateTime(2025, 01, 02, 16, 30, 0), TimeEnd = new DateTime(2025, 01, 02, 19, 30, 0), Price = 135, DoctorId = 19 },

                // Schedules for Doctor 20
                new DoctorSchedule { Id = 39, Name = "Morning Shift", Date = new DateOnly(2025, 01, 03), TimeStart = new DateTime(2025, 01, 03, 8, 0, 0), TimeEnd = new DateTime(2025, 01, 03, 11, 0, 0), Price = 120, DoctorId = 20 },
                new DoctorSchedule { Id = 40, Name = "Evening Shift", Date = new DateOnly(2025, 01, 03), TimeStart = new DateTime(2025, 01, 03, 14, 0, 0), TimeEnd = new DateTime(2025, 01, 03, 17, 0, 0), Price = 140, DoctorId = 20 },

                // Schedules for Doctor 21
                new DoctorSchedule { Id = 41, Name = "Morning Shift", Date = new DateOnly(2025, 01, 04), TimeStart = new DateTime(2025, 01, 04, 9, 0, 0), TimeEnd = new DateTime(2025, 01, 04, 12, 0, 0), Price = 125, DoctorId = 21 },
                new DoctorSchedule { Id = 42, Name = "Evening Shift", Date = new DateOnly(2025, 01, 04), TimeStart = new DateTime(2025, 01, 04, 16, 0, 0), TimeEnd = new DateTime(2025, 01, 04, 19, 0, 0), Price = 145, DoctorId = 21 },

                // Schedules for Doctor 22
                new DoctorSchedule { Id = 43, Name = "Morning Shift", Date = new DateOnly(2025, 01, 05), TimeStart = new DateTime(2025, 01, 05, 8, 30, 0), TimeEnd = new DateTime(2025, 01, 05, 11, 30, 0), Price = 110, DoctorId = 22 },
                new DoctorSchedule { Id = 44, Name = "Evening Shift", Date = new DateOnly(2025, 01, 05), TimeStart = new DateTime(2025, 01, 05, 14, 30, 0), TimeEnd = new DateTime(2025, 01, 05, 17, 30, 0), Price = 130, DoctorId = 22 },

                // Schedules for Doctor 23
                new DoctorSchedule { Id = 45, Name = "Morning Shift", Date = new DateOnly(2025, 01, 06), TimeStart = new DateTime(2025, 01, 06, 9, 0, 0), TimeEnd = new DateTime(2025, 01, 06, 12, 0, 0), Price = 115, DoctorId = 23 },
                new DoctorSchedule { Id = 46, Name = "Evening Shift", Date = new DateOnly(2025, 01, 06), TimeStart = new DateTime(2025, 01, 06, 16, 0, 0), TimeEnd = new DateTime(2025, 01, 06, 19, 0, 0), Price = 135, DoctorId = 23 },

                new DoctorSchedule { Id = 47, Name = "Morning Shift", Date = new DateOnly(2024, 12, 30), TimeStart = new DateTime(2024, 12, 30, 9, 0, 0), TimeEnd = new DateTime(2024, 12, 30, 12, 0, 0), Price = 120, DoctorId = 24 },
                new DoctorSchedule { Id = 48, Name = "Evening Shift", Date = new DateOnly(2024, 12, 30), TimeStart = new DateTime(2024, 12, 30, 16, 0, 0), TimeEnd = new DateTime(2024, 12, 30, 19, 0, 0), Price = 140, DoctorId = 24 }
            );



        }
    }
}
