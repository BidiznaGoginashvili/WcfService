using System;
using System.Linq;
using System.Collections.Generic;
using WCF.Domain.CourseManagement;
using WCF.Infrastructure.DataBase;

namespace StudentsManagementService.Query.CourseQueries
{
    public class CoursesQueryHandler : IRequestHandler<CourseListQuery, IEnumerable<Course>>
    {
        private readonly WCFContext _context;

        public CoursesQueryHandler()
        {
            _context = new WCFContext();
        }

        public IEnumerable<Course> Handle(CourseListQuery request)
        {
            try
            {
                var courses = _context.Set<Course>().AsEnumerable();

                if (courses == null)
                    return default(IEnumerable<Course>);

                if (!string.IsNullOrWhiteSpace(request.Name))
                    courses = courses.Where(course => course.Name.Contains(request.Name));

                return courses;
            }
            catch (Exception exception)
            {
                return default(IEnumerable<Course>);
            }
        }
    }
}