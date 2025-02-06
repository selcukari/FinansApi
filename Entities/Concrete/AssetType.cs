using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AssetType: IEntity
    {
        [Column("asset_type_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AssetTypeId { get; set; }
        public string AssetName { get; set; }

        // Navigation property
        public ICollection<FinancialAsset> FinancialAssets { get; set; }
    }
}
