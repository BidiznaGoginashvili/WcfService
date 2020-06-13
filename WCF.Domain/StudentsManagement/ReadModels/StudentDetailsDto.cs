using WCF.Shared;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCF.Domain.StudentsManagement.ReadModels
{
    [DataContract]
    public class StudentDetailsDto : AggregateRoot
    {
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName{ get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public double GPI { get; set; }

        public StudentDetailsDto()
        {

        }
        public StudentDetailsDto(int studentId, string firstName,string lastName,DateTime birthDate, double gpi)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            GPI = gpi;
        }
    }
}
