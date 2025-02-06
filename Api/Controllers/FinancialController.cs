using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialController : Controller
    {
        IFinancialService _financialService;
        public FinancialController(IFinancialService financialService)
        {
            _financialService = financialService;

        }

        [Route("financials")]
        public List<FinancialAssetDto> Financials()
        {

            return _financialService.GetList();
        }
        [Route("getByFinancial")]
        public List<FinancialAssetDto> GetByFinancial(string sembol)
        {

            return _financialService.GetByFinancial(sembol);
        }
    }
}
