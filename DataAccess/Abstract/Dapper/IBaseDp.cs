using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Dapper
{
    public interface IBaseDp<T> where T : class, IEntity, new()
    {
        T? Get(string? where = null, string? tableName = null, string? connectionString = "");
    }
}
