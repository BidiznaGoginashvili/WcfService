using System.Data.Entity;
using WCF.Domain.StudentsManagement;

namespace WCF.Infrastructure.DataBase
{
    public class WCFContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public WCFContext() : base(@"Server=DESKTOP-KCSUK0G\BIDZINASQL; Database=Management; Trusted_Connection=True")
        {

        }
    }
}
