using System;

namespace Enterspeed.Source.SitecoreCms.V10.Exceptions
{
    public class JobHandlingException : Exception
    {
        public JobHandlingException(string message) : base(message)
        {
        }
    }
}