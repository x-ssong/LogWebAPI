using LogWebApi.MongoDB.Context;
using LogWebApi.MongoDB.Model;
using LogWebApi.MongoDB.Model.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogWebApi.MongoDB.Repository
{
    public class LogRepository : IRepository<LogData>
    {
        private readonly MongoContext _context = null;
        public LogRepository(IOptions<DBSettings> settings)
        {
            _context = new MongoContext(settings);
        }

        public async Task<IEnumerable<LogData>> GetList(QueryLogModel model)
        {
            var builder = Builders<LogData>.Filter;
            FilterDefinition<LogData> filter = builder.Empty;
            if (string.IsNullOrEmpty(model.Level))
            {
                filter = builder.Eq("Level", model.Level);
            }
            if (string.IsNullOrEmpty(model.LogSource))
            {
                filter = filter & builder.Eq("LogSource", model.LogSource);
            }
            if (!string.IsNullOrEmpty(model.Message))
            {
                filter = filter & builder.Regex("Message", new BsonRegularExpression(new Regex(model.Message)));
            }
            if (DateTime.MinValue != model.StartTime)
            {
                filter = filter & builder.Gte("Date", model.StartTime);
            }
            if (DateTime.MinValue != model.EndTime)
            {
                filter = filter & builder.Lte("Date", model.EndTime);
            }
            return await _context.LogDatas.Find(filter)
                .SortByDescending(d => d.Date)
                .Skip((model.PageIndex - 1) * model.PageSize)
                .Limit(model.PageSize).ToListAsync();
        }

        public async Task Add(LogData item)
        {
            await _context.LogDatas.InsertOneAsync(item);
        }

        public async Task<LogData> Get(string id)
        {
            var builder = Builders<LogData>.Filter;
            FilterDefinition<LogData> filter = builder.Empty;
            if (!string.IsNullOrEmpty(id))
            {
                filter = builder.Eq("Id", id);
            }
            return await _context.LogDatas.Find(filter).SingleAsync();
        }

        public async Task<IEnumerable<LogData>> GetAll()
        {
            var builder = Builders<LogData>.Filter;
            FilterDefinition<LogData> filter = builder.Empty;
            return await _context.LogDatas.Find(filter).ToListAsync();
        }

        #region 待实现的方法
        public async Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(string id, string body)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
