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

        [Route("trace")]
        [HttpPost]
        public void Trace([FromBody] LogData value)
        {
            Add(value);
        }
        [Route("debug")]
        [HttpPost]
        public void Debug([FromBody] LogData value)
        {
            Add(value);
        }
        [Route("info")]
        [HttpPost]
        public void Info([FromBody] LogData value)
        {
            Add(value);
        }
        [Route("warn")]
        [HttpPost]
        public void Warn([FromBody] LogData value)
        {
            Add(value);
        }
        [Route("error")]
        [HttpPost]
        public void Error([FromBody] LogData value)
        {
            Add(value);
        }
        [Route("fatal")]
        [HttpPost]
        public void Fatal([FromBody] LogData value)
        {
            Add(value);
        }
        private async void Add(LogData data)
        {
            if (data != null)
            {
                await _logRepository.Add(data);
                if (!string.IsNullOrEmpty(data.Emails))
                {
                    //new EmailHelpers(_appsettings).SendMailAsync(data.Emails, "监测邮件", data.ToString());
                }
            }
        }

        [HttpGet("getlist")]
        public async Task<ResponseModel<IEnumerable<LogData>>> GetList([FromQuery] QueryLogModel model)
        {
            ResponseModel<IEnumerable<LogData>> resp = new ResponseModel<IEnumerable<LogData>>();
            resp.Data = await _logRepository.GetList(model);
            return resp;
        }
    }
}