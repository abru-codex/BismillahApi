namespace AbruApi.Entity
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ItemSetup> ItemSetups { get; set; }
    }
}
