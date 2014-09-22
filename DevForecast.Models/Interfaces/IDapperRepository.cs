using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models.Interfaces
{
    public interface IDapperRepository<T>
    {
        List<T> Get(string sql);
    }
}
