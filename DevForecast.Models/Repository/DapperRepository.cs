using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DevForecast.Models.Interfaces;

namespace DevForecast.Models.Repository
{
    public class DapperRepository<T>:IDapperRepository<T>
    {
        IDbConnection _connection;
        string _sql;
        List<T> _collection;
        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public List<T> Get(string sql)
        {
            _sql = sql;
            using(_connection)
            {
                _connection.Query<T>(_sql, null);
            }
            return _collection;
        }
        public List<T> Collection
        {
            get { return _collection; }
        }
    }
}
