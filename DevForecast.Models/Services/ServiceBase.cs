using DevForecast.Models.Interfaces;
using DevForecast.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models.Services
{
    public class ServiceBase<T>
    {
        IDapperRepository<T> _dapperRepository;

        public ServiceBase(IDapperRepository<T> dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public IDapperRepository<T> DapperRepository
        {
            get { return _dapperRepository; }
        }
    }
}
