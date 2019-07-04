using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWebApi.MongoDB.Model
{
    public class QueryLogModel
    {
        public QueryLogModel()
        {
            PageIndex = 1;
            PageSize = 20;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Level { get; set; }
        public string LogSource { get; set; }
        public string Message { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
