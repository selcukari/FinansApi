using Dapper;
using DataAccess.Abstract.Dapper;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class DpFinancialDal : IDpFinancialDal
    {
        IConfiguration _configuration;
        IBaseDp<FinancialAsset> _baseFinancialDp;

        public DpFinancialDal(IConfiguration configuration, IBaseDp<FinancialAsset> baseDp)
        {
            _configuration = configuration;
            _baseFinancialDp = baseDp;
        }

        public async Task<FinancialAssetDto> GetFinancialInfo(int financialId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                const string query = @"
                SELECT fa.asset_id AS AssetId, fa.asset_type_id AS AssetTypeId, 
                   fa.unit_price AS UnitPrice, fa.price_date AS PriceDate, 
                   fa.source AS Source, 
                   at.asset_type_id AS AssetTypeId, at.asset_name AS AssetName
                FROM financial_assets fa
                LEFT JOIN asset_types at ON fa.asset_type_id = at.asset_type_id
                WHERE fa.asset_id = @AssetId";

                var result = await connection.QueryAsync<FinancialAssetDto, AssetTypeDto, FinancialAssetDto>(
                     query,
                     (fa, at) =>
                     {
                         fa.AssetType = at;
                         return fa;
                     },
                     new { AssetId = financialId },
                     splitOn: "AssetTypeId"
                 );

                if(result == null || !result.Any())
                {
                    return null;
                }

                return result.First();
            }
        }
    }
}
