using Business.Abstract;
using Business.Abstract.Cache;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FinancialManager: IFinancialService
    {
        private readonly IFinancialDal _financialDal;
        private readonly ICacheService _cacheService;
        // private readonly ICacheService _redisCacheService = new RedisCacheService("localhost:6379");

        public FinancialManager(IFinancialDal financialDal, ICacheService cacheService)
        {
            _financialDal = financialDal;
            _cacheService = cacheService;
        }

        public List<FinancialAssetDto> GetByFinancial(string sembol)
        {
            var cacheKey = $"{sembol}";

            var financialListBy = _cacheService.Get<List<FinancialAssetDto>>(cacheKey);

            if (financialListBy == null)
            {
                financialListBy = new List<FinancialAssetDto>(_financialDal.GetByFinancial(sembol));
                _cacheService.Set(cacheKey, financialListBy, TimeSpan.FromMinutes(10));
            }

            return financialListBy;
        }

        public List<FinancialAssetDto> GetList()
        {
            var cacheKey = $"financialList";
            var financialList = _cacheService.Get<List<FinancialAssetDto>>(cacheKey);

            if (financialList == null)
            {
                financialList = new List<FinancialAssetDto>(_financialDal.FinancialList());
                _cacheService.Set(cacheKey, financialList, TimeSpan.FromMinutes(10));
            }

            return financialList;
        }
    }
}
