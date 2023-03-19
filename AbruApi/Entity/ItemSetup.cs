namespace AbruApi.Entity
{
    public class ItemSetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }
        public IList<Item> Items { get; set; }
    }
}
