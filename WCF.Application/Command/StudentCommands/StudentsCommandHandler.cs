using System;
using System.Threading.Tasks;
using StudentsManagementService;
using WCF.Infrastructure.DataBase;
using WCF.Domain.StudentsManagement;
using WCF.Application.Infrastructure;
using WCF.Application.Command.StudentCommands;

namespace WCF.Application.Command.Students
{
    public class StudentsCommandHandler : IRequestHandler<CreateStudentCommand, CommandExecutionResult<Student>>,
        IRequestHandler<UpdateStudentCommand, CommandExecutionResult<Student>>,
        IRequestHandler<DeleteStudentCommand, CommandExecutionResult<Student>>
    {
        private readonly WCFContext _context;

        public StudentsCommandHandler()
        {
            _context = new WCFContext();
        }

        public Task<CommandExecutionResult<Student>> Handle(CreateStudentCommand request)
        {
            try
            {
                var student = new Student(request.FirstName, request.LastName, request.BirthDate,request.Gpi);

                _context.Set<Student>().Add(student);
                _context.SaveChangesAsync();


                return Task.FromResult(new CommandExecutionResult<Student>()
                {
                    Success = true,
                    Data = student
                });
            }
            catch (Exception exception)
            {
                return Task.FromResult(new CommandExecutionResult<Student>()
                {
                    Success = false,
                    Exception = exception
                });
            }
        }

        public Task<CommandExecutionResult<Student>> Handle(UpdateStudentCommand request)
        {
            try
            {
                var student = _context.Set<Student>().Find(request.Id);
                var updated = new Student(request.FirstName, request.LastName, request.BirthDate);
                
                _context.SaveChanges();

                return Task.FromResult(new CommandExecutionResult<Student>()
                {
                    Success = true,
                    Data = student
                });
            }
            catch (Exception exception)
            {
                return Task.FromResult(new CommandExecutionResult<Student>()
                {
                    Success = false,
                    Exception = exception
                });
            }
        }

        public Task<CommandExecutionResult<Student>> Handle(DeleteStudentCommand request)
        {
            try
            {
                var student = _context.Set<Student>().Find(request.Id);

                _context.Set<Student>().Remove(student);
                _context.SaveChanges();

                return Task.FromResult(new CommandExecutionResult<Student>()
                {
                    Success = true
                });
            }
            catch (Exception exception)
            {
                return Task.FromResult(new CommandExecutionResult<Student>()
                {
                    Success = false,
                    Exception = exception
                });
            }
        }
    }
}
