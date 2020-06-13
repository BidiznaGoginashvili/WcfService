using System;
using WCF.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.Domain.LecturerManagement
{
    [DataContract]
    public class Lecturer : AggregateRoot
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        [DataMember]
        public ICollection<CourseManagement.Course> Courses { get; set; }
    }
}
