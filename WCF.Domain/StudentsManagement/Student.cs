using System;
using WCF.Shared;
using System.Runtime.Serialization;

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
        public DateTime BirthDate { get; set; }
        [DataMember]
        public double Gpi { get; set; }

        public Student() { }

        public Student( string firstName, string lastName, DateTime birthDate, double gpi = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gpi = gpi;
        }
    }
}
