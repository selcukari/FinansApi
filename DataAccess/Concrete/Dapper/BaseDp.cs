using Core.Entities.Abstract;
using DataAccess.Abstract.Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class BaseDp<T> : IBaseDp<T> where T : class, IEntity, new()
    {
        IConfiguration _configuration;
        public BaseDp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T? Get(string? where = null, string? tableName = null, string? connectionString = "")
        {
            throw new NotImplementedException();
        }
    }
}
