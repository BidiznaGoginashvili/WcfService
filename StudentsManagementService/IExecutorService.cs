using System.ServiceModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Query.StudentQueries;
using StudentsManagementService.Queries.StudentQueries;
using StudentsManagementService.Command.StudentCommands;
using WCF.Domain.CourseManagement;
using StudentsManagementService.Query.CourseQueries;
using WCF.Domain.StudentsManagement.ReadModels;

namespace StudentsManagementService
{
    [ServiceContract]
    public interface IExecutorService
    {
        [OperationContract]
        string CreateStudent(CreateStudentCommand command);
        [OperationContract]
        IEnumerable<Student> ReadStudent(StudentListQuery query);
        [OperationContract]
        string UpdateStudent(UpdateStudentCommand command);
        [OperationContract]
        string DeleteStudent(DeleteStudentCommand command);
        [OperationContract]
        StudentDetailsDto StudentDetails(StudentDetailsQuery query);
        [OperationContract]
        IEnumerable<Course> ReadCourses(CourseListQuery query);
        [OperationContract]
        List<Course> GetCourseByStudentId(int Id);

    }
}
