using System.Data.Entity;
using WCF.Domain.CourseManagement;
using WCF.Domain.LecturerManagement;
using WCF.Domain.StudentsManagement;
using WCF.Domain.StudentsManagement.ReadModels;

namespace WCF.Infrastructure.DataBase
{
    public class WCFContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentDetailsDto> StudentDetails {get;set;}

        public DbSet<Lecturer> Lecturer{ get; set; }
        public DbSet<Course> Course { get; set; }
        public WCFContext() : base(@"Server=DESKTOP-KCSUK0G\BIDZINASQL; Database=StudentsManagement; Trusted_Connection=True")
        {

        }
    }
}
