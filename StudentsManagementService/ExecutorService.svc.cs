using System.Threading.Tasks;
using System.Collections.Generic;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Queries.StudentQueries;
using StudentsManagementService.Command.StudentCommands;

namespace StudentsManagementService
{
    public class ExecutorService : IExecutorService
    {
        //public TResponse Send<TResponse, TRequest>(TRequest request)
        //{
        //    try
        //    {
        //        var handler = Assembly.GetExecutingAssembly()
        //                    .GetTypes()
        //                       .Where(type => type
        //                           .IsSubclassOf(typeof(IRequestHandler<TRequest, TResponse>)))
        //                           .FirstOrDefault();

        //        var instance = Activator.CreateInstance(handler);
        //        var parameters = new object[] { (TRequest)Activator.CreateInstance(typeof(TRequest)) };
        //        return (TResponse)handler
        //                    .GetMethod("Handle")
        //                    .Invoke(instance, parameters);
        //    }
        //    catch (NullReferenceException) when (request == null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //}
        
        public bool CreateStudent(CreateStudentCommand command)
        {
            StudentsCommandHandler handler = new StudentsCommandHandler();
            return handler.Handle(command);
        }

        public IEnumerable<Student> ReadStudent(StudentListQuery query)
        {
            StudentsQueryHandler handler = new StudentsQueryHandler();
            return handler.Handle(query);
        }

        public bool UpdateStudent(UpdateStudentCommand command)
        {
            StudentsCommandHandler handler = new StudentsCommandHandler();
            return handler.Handle(command);
        }

        public bool DeleteStudent(DeleteStudentCommand command)
        {
            StudentsCommandHandler handler = new StudentsCommandHandler();
            return handler.Handle(command);
        }
    }
}
