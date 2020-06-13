using WCF.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WCF.Domain.LecturerManagement;
using WCF.Domain.StudentsManagement;

namespace WCF.Domain.CourseManagement
{
    [DataContract]
    public class Course : AggregateRoot
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Lecturer Lecturer { get; set; }
        [DataMember]
        public IList<Student> Students { get; set; }
        public Course()
        {
            Students = new List<Student>();
        }
    }
}
