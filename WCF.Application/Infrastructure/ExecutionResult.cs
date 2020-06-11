using System;

namespace WCF.Application.Infrastructure
{
    public class ExecutionResult<TEntity>
    {
        public bool Success { get; set; }
        public TEntity Data { get; set; }
        public Exception Exception { get; set; }
    }
}
