using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Dapper
{
    public interface IDpFinancialService
    {
        Task<FinancialAssetDto> GetFinancial(int financialId);
    }
}
