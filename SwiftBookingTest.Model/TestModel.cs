﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model
{
    public class Department
    {
        public Department()
        {
            this.Courses = new HashSet<Course>();
        }
        // Primary key 
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        // Navigation property 
        public virtual ICollection<Course> Courses { get; private set; }
    }

    public class Course
    {
        public Course()
        {
            this.Instructors = new HashSet<Instructor>();
        }
        // Primary key 
        public int CourseID { get; set; }

        public string Title { get; set; }
        public int Credits { get; set; }

        // Foreign key 
        public int DepartmentID { get; set; }

        // Navigation properties 
        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; private set; }
    }

    public partial class OnlineCourse : Course
    {
        public string URL { get; set; }
    }

    public partial class OnsiteCourse : Course
    {
        public OnsiteCourse()
        {
            Details = new Details();
        }

        public Details Details { get; set; }
    }

    public class Details
    {
        public System.DateTime Time { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
    }

    public class Instructor
    {
        public Instructor()
        {
            this.Courses = new List<Course>();
        }

        // Primary key 
        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public System.DateTime HireDate { get; set; }

        // Navigation properties 
        public virtual ICollection<Course> Courses { get; private set; }

        public virtual ICollection<Coarse> Coarses { get; set;  }
    }

    public class OfficeAssignment
    {
        // Specifying InstructorID as a primary 
        [Key()]
        public Int32 InstructorID { get; set; }

        public string Location { get; set; }

        // When the Entity Framework sees Timestamp attribute 
        // it configures ConcurrencyCheck and DatabaseGeneratedPattern=Computed. 
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        // Navigation property 
        public virtual Instructor Instructor { get; set; }
    }
}
