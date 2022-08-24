using System.Collections.Generic;
using Enterspeed.Source.SitecoreCms.V10.Data.Models;

namespace Enterspeed.Source.SitecoreCms.V10.Services.Contracts
{
    public interface IEnterspeedJobsHandler
    {
        void HandleJobs(IList<EnterspeedJob> jobs);
    }
}