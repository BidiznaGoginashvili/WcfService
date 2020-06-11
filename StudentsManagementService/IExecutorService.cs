using System.ServiceModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Command.Infrastructure;
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
        CommandExecutionResult<Student> CreateStudent(CreateStudentCommand command);
        [OperationContract]
        QueryExecutionResult<IEnumerable<Student>> ReadStudent(StudentListQuery query);
        [OperationContract]
        CommandExecutionResult<Student> UpdateStudent(UpdateStudentCommand command);
        [OperationContract]
        CommandExecutionResult<Student> DeleteStudent(DeleteStudentCommand command);
    }
}
