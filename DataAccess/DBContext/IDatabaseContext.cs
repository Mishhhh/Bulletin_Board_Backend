using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public interface IDatabaseContext
    {
        public Task<IEnumerable<T>> ExecuteCommand<T>(string Query_, object param);
    }
}
