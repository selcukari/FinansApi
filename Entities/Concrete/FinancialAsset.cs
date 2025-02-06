using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FinancialAsset: IEntity
    {
        [Column("asset_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssetId { get; set; }
        public string AssetTypeId { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public string Source { get; set; }

        // Navigation property
        public AssetType AssetType { get; set; }
    }
}
