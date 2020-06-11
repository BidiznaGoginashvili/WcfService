using System.Runtime.Serialization;

namespace StudentsManagementService.Command.StudentCommands
{ 
    [DataContract]
    public class DeleteStudentCommand
    {
        [DataMember]
        public int Id { get; set; }
    }
}
