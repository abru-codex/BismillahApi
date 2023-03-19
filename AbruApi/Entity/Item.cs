namespace AbruApi.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UnitId { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public ItemSetup? ItemSetup { get; set; }
        public IList<ItemBatch>? Batches { get; set; }
        public IList<ItemStocks>? Stocks { get; set; }
    }
}
