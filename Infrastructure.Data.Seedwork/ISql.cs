using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seedwork
{
    public interface ISql
    {
        int ExecuteCommand(string sqlCommand, params object[] parameters);
        IEnumerable ExecuteQuery(string sqlQuery, params object[] parameters);
    }
}
