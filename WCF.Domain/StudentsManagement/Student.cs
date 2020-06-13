using System;
using WCF.Shared;
using System.Collections.Generic;
using WCF.Domain.CourseManagement;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.Domain.StudentsManagement
{
    [DataContract]
    public class Student : AggregateRoot
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public double Gpi { get; set; }
        [DataMember]
        public IList<Course> Courses { get; set; }
        public Student()
        {
            Courses = new List<Course>();
        }

        public Student(string firstName, string lastName,DateTime birthDate, double gpi)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gpi = gpi;
            Courses = new List<Course>();
        }
    }
}
