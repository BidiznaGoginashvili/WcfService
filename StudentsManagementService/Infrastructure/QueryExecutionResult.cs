using System.Runtime.Serialization;

namespace StudentsManagementService.Command.Infrastructure
{
    [DataContract]
    public class QueryExecutionResult<TEnity> : ExecutionResult<TEnity>
    {
    }
}
