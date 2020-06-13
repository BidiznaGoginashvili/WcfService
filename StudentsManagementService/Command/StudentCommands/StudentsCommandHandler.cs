using System;
using System.Linq;
using WCF.Infrastructure.DataBase;
using WCF.Domain.CourseManagement;
using WCF.Domain.StudentsManagement;
using System.Data.Entity.Validation;
using StudentsManagementService.Extensions;
using WCF.Domain.StudentsManagement.ReadModels;

namespace StudentsManagementService.Command.StudentCommands
{
    public class StudentsCommandHandler : IRequestHandler<CreateStudentCommand, string>,
        IRequestHandler<UpdateStudentCommand, string>,
        IRequestHandler<DeleteStudentCommand, string>
    {
        private readonly WCFContext _context;

        public StudentsCommandHandler()
        {
            _context = new WCFContext();
        }

        public string Handle(CreateStudentCommand request)
        {
            try
            {
                var student = new Student(request.FirstName, request.LastName, request.BirthDate, request.Gpi);

                _context.Student.Add(student);
               
                _context.SaveChanges();

                var studentDetails = new StudentDetailsDto(student.Id, student.FirstName,student.LastName,student.BirthDate, student.Gpi);

                _context.StudentDetails.Add(studentDetails);
                _context.SaveChangesAsync();

                return "succeded";
            }
            catch (DbEntityValidationException exception)
            {
                return exception.GetValidations();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Handle(UpdateStudentCommand request)
        {
            try
            {
                if (request.Id == 0)
                    return "student should be more than 0";

                var student = _context.Set<Student>().Find(request.Id);
                if (student == null)
                    return "student not found";

                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.BirthDate = request.BirthDate;
                student.Gpi = request.Gpi;

                var studentDetails = _context.Set<StudentDetailsDto>().Find(request.Id);
                if (studentDetails != null)
                {
                    studentDetails.FirstName = request.FirstName;
                    studentDetails.LastName = request.LastName;
                    studentDetails.BirthDate = request.BirthDate;
                    studentDetails.GPI = student.Gpi;
                }
                _context.SaveChanges();

                return "succeded";
            }
            catch (DbEntityValidationException exception)
            {
                return exception.GetValidations();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Handle(DeleteStudentCommand request)
        {
            try
            {
                var student = _context.Set<Student>().Find(request.Id);

                if (student == null)
                    return "student not found";

                _context.Set<Student>().Remove(student);
                _context.SaveChanges();

                return "succeded";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
