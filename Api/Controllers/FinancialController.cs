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

        [Route("financials")] // ef
        public List<FinancialAssetDto> Financials()
        {

            return _financialService.GetList();
        }
        [Route("dbfinancials")] // dapper
        public Task<List<FinancialAssetDto>> DbFinancials()
        {

            return _dpFinancialService.GetListDb();
        }
        [Route("getByFinancial")] // ef
        public List<FinancialAssetDto> GetByFinancial(string sembol)
        {

            return _financialService.GetByFinancial(sembol);
        }
        [Route("getFinancial")] // dapper
        public Task<FinancialAssetDto> GetFinancial(int financialId)
        {

            return _dpFinancialService.GetFinancial(financialId);
        }
    }
}
