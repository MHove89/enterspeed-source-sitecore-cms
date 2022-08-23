using System.Web.Mvc;
using Enterspeed.Source.SitecoreCms.V10.Data.Repositories;
using Enterspeed.Source.SitecoreCms.V10.Models;

namespace Enterspeed.Source.SitecoreCms.V10.Controllers
{
    public class EnterspeedController : Controller
    {
        private readonly IEnterspeedJobRepository _enterspeedJobRepository;

        public EnterspeedController(IEnterspeedJobRepository enterspeedJobRepository)
        {
            _enterspeedJobRepository = enterspeedJobRepository;
        }

        public ActionResult Index()
        {
            var failedJobs = _enterspeedJobRepository.GetFailedJobs();
            var pendingJobs = _enterspeedJobRepository.GetPendingJobs(1000);

            var vm = new EnterspeedDashboardViewModel()
            {
                FailedJobs = failedJobs,
                PendingJobs = pendingJobs
            };

            return View(vm);
        }
    }
}