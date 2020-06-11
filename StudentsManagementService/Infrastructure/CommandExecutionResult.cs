using System.Runtime.Serialization;

namespace StudentsManagementService.Command.Infrastructure
{
    [DataContract]
    public class CommandExecutionResult<TEnity> : ExecutionResult<TEnity>
    {
    }
}
