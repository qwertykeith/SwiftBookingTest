using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model
{
    public class Coarse : BaseClass
    {
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
