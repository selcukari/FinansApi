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

        public DpFinancialManager(IDpFinancialDal financialDal)
        {
            _dpFinancialDal = financialDal;
        }

        public Task<FinancialAssetDto> GetFinancial(int financialId)
        {
            return _dpFinancialDal.GetFinancialInfo(financialId);
        }

        public Task<List<FinancialAssetDto>> GetListDb()
        {
            return _dpFinancialDal.FinancialListDb();
        }
    }
}
