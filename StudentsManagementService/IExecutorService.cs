using System.ServiceModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Queries.StudentQueries;
using StudentsManagementService.Command.StudentCommands;

namespace StudentsManagementService
{
    [ServiceContract]
    public interface IExecutorService
    {
        //[OperationContract]
        //TResponse Send<TResponse, TRequest>(TRequest request);
        [OperationContract]
        bool CreateStudent(CreateStudentCommand command);
        [OperationContract]
        IEnumerable<Student> ReadStudent(StudentListQuery query);
        [OperationContract]
        bool UpdateStudent(UpdateStudentCommand command);
        [OperationContract]
        bool DeleteStudent(DeleteStudentCommand command);
    }
}
