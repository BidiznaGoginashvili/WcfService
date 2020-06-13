using System.Runtime.Serialization;

namespace StudentsManagementService.Query.StudentQueries
{
    [DataContract]
    public class StudentDetailsQuery
    {
        [DataMember]
        public int Id { get; set; }
    }
}