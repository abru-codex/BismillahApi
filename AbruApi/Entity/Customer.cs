namespace AbruApi.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? SalesPersonId { get; set; }
        public SalesPerson? SalesPerson { get; set; }
    }
}
