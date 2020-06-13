using System.Collections.Generic;
using WCF.Domain.StudentsManagement;
using StudentsManagementService.Query.StudentQueries;
using StudentsManagementService.Queries.StudentQueries;
using StudentsManagementService.Command.StudentCommands;
using WCF.Domain.CourseManagement;
using StudentsManagementService.Query.CourseQueries;
using WCF.Domain.StudentsManagement.ReadModels;
using WCF.Infrastructure.DataBase;
using System.Linq;

namespace StudentsManagementService
{
    public class ExecutorService : IExecutorService
    {
        private readonly WCFContext _context;

        public ExecutorService()
        {
            _context = new WCFContext();
        }

        public string CreateStudent(CreateStudentCommand command)
        {
            //command.CourseIds = new List<int>() { 4 };
            StudentsCommandHandler handler = new StudentsCommandHandler();
            return handler.Handle(command);
        }

        public IEnumerable<Student> ReadStudent(StudentListQuery query)
        {
            StudentsQueryHandler handler = new StudentsQueryHandler();
            return handler.Handle(query);
        }

        public string UpdateStudent(UpdateStudentCommand command)
        {
            StudentsCommandHandler handler = new StudentsCommandHandler();
            return handler.Handle(command);
        }

        public string DeleteStudent(DeleteStudentCommand command)
        {
            StudentsCommandHandler handler = new StudentsCommandHandler();
            return handler.Handle(command);
        }

        public StudentDetailsDto StudentDetails(StudentDetailsQuery query)
        {
            StudentsQueryHandler handler = new StudentsQueryHandler();
            return handler.Handle(query);
        }

        public IEnumerable<Course> ReadCourses(CourseListQuery query)
        {
            CoursesQueryHandler handler = new CoursesQueryHandler();
            return handler.Handle(query);
        }

        public List<Course> GetCourseByStudentId(int Id)
        {
            var courses = _context.Set<Student>().Include("Courses").Where(x=>x.Id == Id).SelectMany(student=> student.Courses).ToList();
            
            return courses == null ? default(List<Course>) : courses;
        }
    }
}
