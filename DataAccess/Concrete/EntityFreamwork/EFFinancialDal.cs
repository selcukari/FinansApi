using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EFFinancialDal : EFEntityRepositoryBase<FinancialAsset, FinancialDbContext>, IFinancialDal
    {
        private readonly FinancialDbContext _context;
        public EFFinancialDal(FinancialDbContext context): base(context)
        {
            _context = context;
        }

        public List<FinancialAssetDto> GetByFinancial(string sembol)
        {
            var financialAssets = _context.FinancialAssets
           .Include(fa => fa.AssetType)
           .Where(fa => fa.AssetTypeId == sembol)
           .Select(fa => new FinancialAssetDto
           {
               AssetId = fa.AssetId,
               AssetTypeId = fa.AssetTypeId,
               PriceDate = fa.PriceDate,
               UnitPrice = fa.UnitPrice,
               Source = fa.Source,
               AssetType = new AssetTypeDto
               {
                   AssetTypeId = fa.AssetType.AssetTypeId,
                   AssetName = fa.AssetType.AssetName
               }
           }).ToList();

            return financialAssets;
        }

        public List<FinancialAssetDto> FinancialList()
        {
            var financialAssets = _context.FinancialAssets
           .Include(fa => fa.AssetType)
           .Select(fa => new FinancialAssetDto
           {
               AssetId = fa.AssetId,
               AssetTypeId = fa.AssetTypeId,
               PriceDate = fa.PriceDate,
               UnitPrice = fa.UnitPrice,
               Source = fa.Source,
               AssetType = new AssetTypeDto
               {
                   AssetTypeId = fa.AssetType.AssetTypeId,
                   AssetName = fa.AssetType.AssetName
               }
           }).ToList();

            return financialAssets;

        }
    }
}
