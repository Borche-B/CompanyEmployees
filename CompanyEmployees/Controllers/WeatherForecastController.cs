using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repositoryManager;


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILoggerManager logger, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    _logger.LogInfo("Info message from our controller.");
        //    _logger.LogDebug("Debug message from our controller.");
        //    _logger.LogWarn("Warn message from our controller.");
        //    _logger.LogError("Error message from our controller.");

        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //_repositoryManager.Company
            //_repositoryManager.Employee

            return new string[] { "value1", "value2" };
        }
    }
}
