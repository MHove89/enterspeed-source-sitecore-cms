using System;
using Enterspeed.Source.SitecoreCms.V10.Services.Contracts;
using Sitecore.Tasks.Scheduler;

namespace Enterspeed.Source.SitecoreCms.V10.Agents
{
    public class DeleteOlderEnterspeedJobs : BaseAgent
    {
        private readonly IEnterspeedJobsHandlingService _enterspeedJobsHandlingService;
        private readonly IEnterspeedSitecoreLoggingService _loggingService;

        public DeleteOlderEnterspeedJobs(IEnterspeedJobsHandlingService enterspeedJobsHandlingService,
            IEnterspeedSitecoreLoggingService loggingService)
        {
            _enterspeedJobsHandlingService = enterspeedJobsHandlingService;
            _loggingService = loggingService;
        }

        public void Run()
        {
            try
            {
                _enterspeedJobsHandlingService.InvalidateOldProcessingJobs();
            }
            catch (Exception e)
            {
                _loggingService.Error("Something went wrong when handling jobs ", e);
            }

        }

        // TOOD: Implement
        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override string Name { get; }
        public override DateTime LastRun { get; protected set; }
        public override ISchedulerStrategy Strategy { get; }
        public override AgentDetails Details { get; }
    }
}
