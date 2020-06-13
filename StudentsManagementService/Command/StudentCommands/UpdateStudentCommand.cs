using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StudentsManagementService.Command.StudentCommands
{
    [DataContract]
    public class UpdateStudentCommand
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public double Gpi{ get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
