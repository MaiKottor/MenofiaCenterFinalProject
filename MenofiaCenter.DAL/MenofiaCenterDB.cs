namespace MenofiaCenter.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MenofiaCenterDB : DbContext
    {
        public MenofiaCenterDB()
            : base("name=MenofiaCenterDB")
        {
        }

        public virtual DbSet<attendance> attendances { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<courses_category> courses_category { get; set; }
        public virtual DbSet<instructor> instructors { get; set; }
        public virtual DbSet<instructor_phone> instructor_phone { get; set; }
        public virtual DbSet<lab> labs { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<news_type> news_type { get; set; }
        public virtual DbSet<parenter> parenters { get; set; }
        public virtual DbSet<parenters_phones> parenters_phones { get; set; }
        public virtual DbSet<qualification> qualifications { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<student_course> student_course { get; set; }
        public virtual DbSet<student_phone> student_phone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>()
                .HasMany(e => e.attendances)
                .WithRequired(e => e.course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.student_course)
                .WithRequired(e => e.course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<courses_category>()
                .HasMany(e => e.courses)
                .WithRequired(e => e.courses_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<instructor>()
                .HasMany(e => e.instructor_phone)
                .WithRequired(e => e.instructor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<instructor>()
                .HasMany(e => e.qualifications)
                .WithMany(e => e.instructors)
                .Map(m => m.ToTable("instructor_qualifications").MapLeftKey("instructor_id").MapRightKey("qualification_id"));

            modelBuilder.Entity<parenter>()
                .HasMany(e => e.parenters_phones)
                .WithRequired(e => e.parenter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.courses)
                .WithRequired(e => e.service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.labs)
                .WithRequired(e => e.service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.attendances)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.student_course)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.student_phone)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
