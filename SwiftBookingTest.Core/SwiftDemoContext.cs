using SwiftBookingTest.Core.Configurations;
using SwiftBookingTest.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using SwiftBookingTest.CoreContracts;
using System;

namespace SwiftBookingTest.Core
{
    /// <summary>
    /// Represents SwiftDemoContext class
    /// </summary>
    public class SwiftDemoContext : DbContext, ISwiftDemoContext
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="SwiftDemoContext"/> class.
        /// </summary>
        public SwiftDemoContext()
            : base("SwiftBookingTest")
        {
        }

        //protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        //{
        //    //return base.ShouldValidateEntity(entityEntry)
        //    //    || (entityEntry.State == EntityState.Deleted
        //    //    && entityEntry.Entity is ClientRecord);
        //}

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());

            //result.ValidationErrors.Add(new DbValidationError("propertyName", "ErrorMessage"));

            return base.ValidateEntity(entityEntry, items);
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Stop pluralizing of table name in database
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //set rules on client and phone number table
            //modelBuilder.Configurations.Add(new ClientRecordConfiguration());
            //modelBuilder.Configurations.Add(new ClientPhoneConfiguration());

            #region many to many relationship
            modelBuilder.Entity<Student>()
                .HasMany<Coarse>(s => s.Coarses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("CoarseId");
                    cs.ToTable("StudentCoarse");
                });
            #endregion

            #region "Many to many relationship with same coarse table to instructor"
            //many to many relationship
            modelBuilder.Entity<Instructor>()
                .HasMany<Coarse>(s => s.Coarses)
                .WithMany(c => c.Instructors)
                .Map(cs =>
                {
                    cs.MapLeftKey("InstructorId");
                    cs.MapRightKey("CoarseId");
                    cs.ToTable("InstructorCoarse");
                });
            #endregion

            #region "Extend table"
            ////splitting or extending api
            //modelBuilder.Entity<Student>()
            //    .Map(mc =>
            //    {
            //        mc.Properties(a => new { a.Id, a.StudentName });
            //        mc.ToTable("Student");
            //    }).
            //    Map(mc =>
            //    {
            //        mc.Properties(a => new { a.Id, a.StudentRollNumber });
            //        mc.ToTable("StudentDetail");
            //    });
            #endregion

        }

   
        /// <summary>
        /// Gets or sets the client records.
        /// </summary>
        /// <value>
        /// The client records.
        /// </value>
        public DbSet<ClientRecord> ClientRecords { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public DbSet<ClientPhone> ClientPhones { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public DbSet<PhoneNumber> PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public DbSet<Coarse> Coarses { get; set; }

        /// <summary>
        /// Gets or sets the office assignments.
        /// </summary>
        /// <value>
        /// The office assignments.
        /// </value>
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        /// <summary>
        /// Gets or sets the instructors.
        /// </summary>
        /// <value>
        /// The instructors.
        /// </value>
        public DbSet<Instructor> Instructors { get; set; }


    }
}
