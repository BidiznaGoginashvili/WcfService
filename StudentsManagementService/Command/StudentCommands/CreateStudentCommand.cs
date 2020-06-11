using System;
using System.Runtime.Serialization;

namespace StudentsManagementService.Command.StudentCommands
{
    [DataContract]
    public class CreateStudentCommand
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public double Gpi { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
