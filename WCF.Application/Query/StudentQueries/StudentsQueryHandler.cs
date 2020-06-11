using System;
using System.Linq;
using System.Threading.Tasks;
using StudentsManagementService;
using WCF.Application.Execution;
using System.Collections.Generic;
using WCF.Infrastructure.DataBase;
using WCF.Domain.StudentsManagement;

namespace WCF.Application.Query.StudentQueries
{
    public class StudentsQueryHandler : IRequestHandler<StudentListQuery, QueryExecutionResult<IEnumerable<Student>>>
    {
        private readonly WCFContext _context;

        public StudentsQueryHandler()
        {
            _context = new WCFContext();
        }

        public Task<QueryExecutionResult<IEnumerable<Student>>> Handle(StudentListQuery request)
        {
            try
            {
                var students = _context.Set<Student>().AsNoTracking().ToList();
                
                return Task.FromResult(new QueryExecutionResult<IEnumerable<Student>>()
                {
                    Success = true,
                    Data = students
                });
            }
            catch (Exception exception)
            {
                return Task.FromResult(new QueryExecutionResult<IEnumerable<Student>>()
                {
                    Success = false,
                    Exception = exception
                });
            }
        }
    }
}
