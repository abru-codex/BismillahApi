using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbruApi.Entity
{
    public class ItemBatch
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
    }
}
