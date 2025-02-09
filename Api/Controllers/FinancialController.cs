using Business.Abstract;
using Business.Abstract.Dapper;
using DataAccess.Abstract.Dapper;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialController : Controller
    {
        private readonly IFinancialService _financialService;
        private readonly IDpFinancialService _dpFinancialService;

        public FinancialController(IFinancialService financialService, IDpFinancialService dpFinancialService)
        {
            _financialService = financialService;
            _dpFinancialService = dpFinancialService;

        }

        [Route("financials"), ResponseCache(Duration = 60)] // ef, memorycahe
        public List<FinancialAssetDto> Financials()
        {

            return _financialService.GetList();
        }
        [Route("dpfinancials"), ResponseCache(Duration = 60)] // dapper
        public Task<List<FinancialAssetDto>> DbFinancials()
        {

            return _dpFinancialService.GetListDb();
        }
        [Route("getByFinancial")] // ef, rediscache
        public List<FinancialAssetDto> GetByFinancial(string sembol)
        {

            return _financialService.GetByFinancial(sembol);
        }
        [Route("getFinancial"), ResponseCache(Duration = 60)] // dapper
        public Task<FinancialAssetDto> GetFinancial(int financialId)
        {

            return _dpFinancialService.GetFinancial(financialId);
        }
    }
}
