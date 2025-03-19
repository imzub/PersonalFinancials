using Microsoft.AspNetCore.Mvc;
using PersonalFinancialsMvcCore.Models;
using System.Diagnostics;
using PersonalFinancials.DataAccess;

namespace PersonalFinancialsMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventLogDataAccess _eventLogger;
        private readonly ExceptionLogDataAccess _exceptionLogger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _eventLogger = new EventLogDataAccess();
            _exceptionLogger = new ExceptionLogDataAccess();
        }

        public IActionResult Index()
        {
            _eventLogger.LogEvent(new EventLogModel
            {
                EventType = "Load",
                EventMessage = "Home page loaded successfully.",
                EventSource = "HomeController",
                UserName = "System"
            });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            _exceptionLogger.LogException(new Exception("An error occurred while processing your request."));

            return View(errorViewModel);
        }
    }
}
