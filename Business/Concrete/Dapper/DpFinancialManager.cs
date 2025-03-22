using Business.Abstract.Cache;
using Business.Abstract.Dapper;
using DataAccess.Abstract.Dapper;
using Entities.Dto;

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
