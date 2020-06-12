using System;
using System.Runtime.Serialization;

namespace StudentsManagementService.Queries.StudentQueries
{
    [DataContract]
    public class StudentListQuery
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}
