using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class FinancialAssetDto
    {
        [Column("asset_id")]
        public int AssetId { get; set; }
        [Column("asset_type_id")]
        public string AssetTypeId { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public string Source { get; set; }

        public AssetTypeDto AssetType { get; set; }
    }
}
