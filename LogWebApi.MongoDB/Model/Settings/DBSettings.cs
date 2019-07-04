using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWebApi.MongoDB.Model.Settings
{
    public class DBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LogCollectionName { get; set; }
    }
}
