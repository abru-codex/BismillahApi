namespace AbruApi.Entity
{
    public class ItemStocks
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int ItemBatchId { get; set; }
        public ItemBatch ItemBatch { get; set; }
        public int PurchasedQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
