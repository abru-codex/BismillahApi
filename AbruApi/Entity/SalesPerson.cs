namespace AbruApi.Entity
{
    public class SalesPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Designation { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public IList<Customer>? Customers { get; set; }
    }
}
