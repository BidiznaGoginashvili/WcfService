namespace WCF.Application.Command.StudentCommands
{
    public class DeleteStudentCommand
    {
        public int Id { get; set; }

        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
