using System;
using System.Linq;
using System.Collections.Generic;
using WCF.Infrastructure.DataBase;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Query.StudentQueries;
using WCF.Domain.StudentsManagement.ReadModels;

namespace StudentsManagementService.Queries.StudentQueries
{
    public class StudentsQueryHandler : IRequestHandler<StudentDetailsQuery, StudentDetailsDto>,
                 IRequestHandler<StudentListQuery, IEnumerable<Student>>
    {
        private readonly WCFContext _context;

        public StudentsQueryHandler()
        {
            _context = new WCFContext();
        }

        public StudentDetailsDto Handle(StudentDetailsQuery request)
        {
            try
            {
                var student = _context.Set<StudentDetailsDto>().FirstOrDefault(std => std.StudentId == request.Id);

                if (student == null)
                    return default(StudentDetailsDto);

                return student;
            }
            catch (Exception exception)
            {
                return default(StudentDetailsDto);
            }
        }

        public IEnumerable<Student> Handle(StudentListQuery request)
        {
            try
            {
                var students = _context.Set<Student>().AsEnumerable();

                if (students == null)
                    return default(IEnumerable<Student>);
                if (request.Id > 0)
                    students = students.Where(student => student.Id == request.Id);
                if (!string.IsNullOrWhiteSpace(request.FirstName))
                    students = students.Where(student => student.FirstName.Contains(request.LastName));
                if (!string.IsNullOrWhiteSpace(request.LastName))
                    students = students.Where(student => student.LastName.Contains(request.LastName));

                return students.ToList();
            }
            catch (Exception exception)
            {
                return default(IEnumerable<Student>);
            }
        }
    }
}
