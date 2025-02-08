using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class FinancialAssetDto
    {
        public int AssetId { get; set; }
        public string AssetTypeId { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public string Source { get; set; }

        public AssetTypeDto AssetType { get; set; }
    }
}
