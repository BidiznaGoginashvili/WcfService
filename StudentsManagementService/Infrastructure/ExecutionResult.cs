using System;
using System.Runtime.Serialization;

namespace StudentsManagementService.Command.Infrastructure
{
    [DataContract]
    public class ExecutionResult<TEntity>
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public TEntity Data { get; set; }
        [DataMember]
        public Exception Exception { get; set; }
    }
}
