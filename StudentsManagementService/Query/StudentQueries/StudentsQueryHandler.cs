using System;
using System.Linq;
using System.Collections.Generic;
using WCF.Infrastructure.DataBase;
using WCF.Domain.StudentsManagement;

namespace StudentsManagementService.Queries.StudentQueries
{
    public class StudentsQueryHandler : IRequestHandler<StudentListQuery, IEnumerable<Student>>
    {
        private readonly WCFContext _context;

        public StudentsQueryHandler()
        {
            _context = new WCFContext();
        }

        public IEnumerable<Student> Handle(StudentListQuery request)
        {
            try
            {
                var students = _context.Set<Student>().AsEnumerable();
                
                if(students == null)
                    return default(IEnumerable<Student>);

                if (!string.IsNullOrWhiteSpace(request.FirstName))
                    students = students.Where(student => student.FirstName.Contains(request.FirstName));
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
