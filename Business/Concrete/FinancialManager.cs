using Business.Abstract;
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
        private IFinancialDal _financialDal;

        public FinancialManager(IFinancialDal financialDal)
        {
            _financialDal = financialDal;
        }

        public List<FinancialAssetDto> GetByFinancial(string sembol)
        {
            return new List<FinancialAssetDto>(_financialDal.GetByFinancial(sembol));
        }

        public List<FinancialAssetDto> GetList()
        {
            return new List<FinancialAssetDto>(_financialDal.FinancialList());
        }
    }
}
