using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Domain.Enums
{
    public class PollyPolicy
    {
        public const string TIMEOUT_POLICY = "TimeoutPolicy";
        public const string RETRY_POLICY = "RetryPolicy";
    }
}
