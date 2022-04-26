using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hospital
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookAppointment> BookAppointments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<DoctorLogin> DoctorLogins { get; set; }
        public virtual DbSet<PatientRegister> PatientRegisters { get; set; }
        public virtual DbSet<ReportGeneration> ReportGenerations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=localhost;database=Hospital; username=postgres; password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<BookAppointment>(entity =>
            {
                entity.ToTable("book_appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppintmentId).HasColumnName("appintment_id");

                entity.Property(e => e.AppoinmentTime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("appoinment_time");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.AppointmentMesaage)
                    .HasMaxLength(100)
                    .HasColumnName("appointment_mesaage");

                entity.Property(e => e.Service)
                    .HasMaxLength(100)
                    .HasColumnName("service");

                entity.HasOne(d => d.Appintment)
                    .WithMany(p => p.BookAppointments)
                    .HasForeignKey(d => d.AppintmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patient");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contact");

                entity.HasIndex(e => e.Email, "contact_email_key")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .HasColumnName("lastname");

                entity.Property(e => e.Usermeassgae)
                    .HasMaxLength(100)
                    .HasColumnName("usermeassgae");
            });

            modelBuilder.Entity<DoctorLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("doctor_login");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<PatientRegister>(entity =>
            {
                entity.ToTable("patient_register");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
            });

            modelBuilder.Entity<ReportGeneration>(entity =>
            {
                entity.ToTable("report_generation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.PatientDetails).HasColumnName("patient_details");

                entity.Property(e => e.Recommendation).HasColumnName("recommendation");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Service)
                    .HasColumnType("character varying")
                    .HasColumnName("service");

                entity.Property(e => e.TreatmentDetails).HasColumnName("treatment_details");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
