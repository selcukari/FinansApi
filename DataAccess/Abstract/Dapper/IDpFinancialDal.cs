﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Dapper
{
    public interface IDpFinancialDal
    {
        Task<FinancialAssetDto> GetFinancialInfo(int financialId);
        Task<List<FinancialAssetDto>> FinancialListDb();
    }
}
