using LogWebApi.MongoDB.Model;
using LogWebApi.MongoDB.Model.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWebApi.MongoDB.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly string _logCollection;
        public MongoContext(IOptions<DBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.DatabaseName);
            }
            _logCollection = settings.Value.LogCollectionName;
        }

        public IMongoCollection<LogData> LogDatas
        {
            get
            {
                return _database.GetCollection<LogData>(_logCollection);
            }
        }
    }
}
