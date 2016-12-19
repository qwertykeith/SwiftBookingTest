using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SwiftBookingTest.Model
{
    [DataContract]
    public class Student : BaseClass
    {
        [Required, DataMember]
        public string StudentName { get; set; }

        public string StudentRollNumber { get; set; }

        public virtual ICollection<Coarse> Coarses { get; set; }
    }
}
