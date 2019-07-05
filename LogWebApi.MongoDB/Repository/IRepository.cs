using LogWebApi.MongoDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWebApi.MongoDB.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetList(QueryLogModel model);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Add(T item);
        Task<bool> Remove(string id);
        Task<bool> Update(string id, string body);
    }
}
