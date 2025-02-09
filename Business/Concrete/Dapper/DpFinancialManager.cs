using Business.Abstract.Cache;
using Business.Abstract.Dapper;
using DataAccess.Abstract;
using DataAccess.Abstract.Dapper;
using DataAccess.Concrete.Dapper;
using DataAccess.Concrete.EntityFreamwork;
using Entities.Dto;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Dapper
{
    public class DpFinancialManager : IDpFinancialService
    {
        private readonly IDpFinancialDal _dpFinancialDal;
        private readonly ICacheService _cacheService;

        public DpFinancialManager(IDpFinancialDal financialDal, ICacheService cacheService)
        {
            _dpFinancialDal = financialDal;
            _cacheService = cacheService;
        }

        public async Task<FinancialAssetDto> GetFinancial(int financialId)
        {
            var cacheKey = $"{financialId}";
            var financial = _cacheService.Get<FinancialAssetDto>(cacheKey);

            if (financial == null)
            {
                financial = await _dpFinancialDal.GetFinancialInfo(financialId);
                _cacheService.Set(cacheKey, financial, TimeSpan.FromMinutes(10));
            }

            return financial;
        }

        public Task<List<FinancialAssetDto>> GetListDb()
        {
            return _dpFinancialDal.FinancialListDb();
        }
    }
}
