using System.Runtime.Serialization;

namespace StudentsManagementService.Query.CourseQueries
{
    [DataContract]
    public class CourseListQuery
    {
        [DataMember]
        public string Name { get; set; }
    }
}