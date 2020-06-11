using System;
using System.Linq;
using System.Collections.Generic;
using WCF.Infrastructure.DataBase;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Command.Infrastructure;

namespace StudentsManagementService.Queries.StudentQueries
{
    public class StudentsQueryHandler : IRequestHandler<StudentListQuery, QueryExecutionResult<IEnumerable<Student>>>
    {
        private readonly WCFContext _context;

        public StudentsQueryHandler()
        {
            _context = new WCFContext();
        }

        public QueryExecutionResult<IEnumerable<Student>> Handle(StudentListQuery request)
        {
            try
            {
                var students = _context.Set<Student>().AsNoTracking().ToList();

                if (!string.IsNullOrWhiteSpace(request.FirstName))
                    students.Where(student => student.FirstName.Contains(request.FirstName));
                if (!string.IsNullOrWhiteSpace(request.LastName))
                    students.Where(student => student.LastName.Contains(request.LastName));

                return new QueryExecutionResult<IEnumerable<Student>>()
                {
                    Success = true,
                    Data = students
                };
            }
            catch (Exception exception)
            {
                return new QueryExecutionResult<IEnumerable<Student>>()
                {
                    Success = false,
                    Exception = exception
                };
            }
        }
    }
}
