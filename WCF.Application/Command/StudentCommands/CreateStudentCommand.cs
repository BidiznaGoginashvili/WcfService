using System;

namespace WCF.Application.Command.StudentCommands
{
    public class CreateStudentCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Gpi { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateStudentCommand(int id, string firstName, string lastName, double gpi, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Gpi = gpi;
            BirthDate = birthDate;
        }
    }
}
