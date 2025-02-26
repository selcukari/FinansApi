﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFinancialDal : IEntityRepository<FinancialAsset>
    {
        List<FinancialAssetDto> FinancialList();
        List<FinancialAssetDto> GetByFinancial(string sembol);
    }
}
