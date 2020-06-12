using System;
using WCF.Infrastructure.DataBase;
using WCF.Domain.StudentsManagement;

namespace StudentsManagementService.Command.StudentCommands
{
    public class StudentsCommandHandler : IRequestHandler<CreateStudentCommand, bool>,
        IRequestHandler<UpdateStudentCommand, bool>,
        IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly WCFContext _context;

        public StudentsCommandHandler()
        {
            _context = new WCFContext();
        }

        public bool Handle(CreateStudentCommand request)
        {
            try
            {
                if (request.BirthDate == null)
                    return false;

                var student = new Student(request.FirstName, request.LastName, request.BirthDate, request.Gpi);

                _context.Set<Student>().Add(student);
                _context.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool Handle(UpdateStudentCommand request)
        {
            try
            {
                if (request.Id == 0 || request.BirthDate == null)
                    return false;

                var student = _context.Set<Student>().Find(request.Id);
                if (student == null)
                    return false;
                var updated = new Student(request.FirstName, request.LastName, request.BirthDate);

                _context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool Handle(DeleteStudentCommand request)
        {
            try
            {
                if (request.Id == 0)
                    return false;

                var student = _context.Set<Student>().Find(request.Id);

                if (student == null)
                    return false;

                _context.Set<Student>().Remove(student);
                _context.SaveChanges();

                return true;
            }

            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
