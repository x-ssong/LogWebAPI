using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogWebApi.MongoDB.Model;
using LogWebApi.MongoDB.Model.Settings;
using LogWebApi.MongoDB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LogWebApi.MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogRepository _logRepository;
        IOptions<AppSettings> _appsettings;
        public LogController(IRepository<LogData> logRepository, IOptions<AppSettings> appsettings)
        {
            _logRepository = (LogRepository)logRepository;
            _appsettings = appsettings;
        }
    }
}