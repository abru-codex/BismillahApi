using Microsoft.EntityFrameworkCore;
using System.Data;
using AbruApi.Entity;

namespace AbruApi.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemBatch> Batches { get; set; }
        public DbSet<ItemSetup> ItemSetups { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemStocks> Stocks { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<TrxCategory>()
            //    .HasOne(t => t.Category)
            //    .WithMany(tr => tr.TrxCategories)
            //    .HasForeignKey(trx=>trx.CategoryId);

            //modelBuilder.Entity<TrxCategory>()
            //    .HasOne(t => t.Trx)
            //    .WithMany(tr => tr.TrxCategories)
            //    .HasForeignKey(trx=>trx.TrxId);

            //modelBuilder.Entity<TrxCategory>().HasKey(tc=> new {tc.TrxId, tc.CategoryId});

            modelBuilder.Entity<User>().HasData(new User { Id=Guid.NewGuid(),Name="System User",UserName="admin",Email="admin@gmail.com",Password="12345",Role="Admin" });
            modelBuilder.Entity<SalesPerson>().HasData(new List<SalesPerson> { new SalesPerson { Id = 1, Name = "Sales Man-1", Designation = "Sales Man", Address = "Dhaka", PhoneNumber = "01700000" }, new SalesPerson { Id = 1, Name = "Sales Man-2", Designation = "Executive", Address = "Noakhali", PhoneNumber = "01800000" } });
            modelBuilder.Entity<Customer>().HasData(new List<Customer> { new Customer { Id = 1, Name = "Customer -1", SalesPersonId = 2, Address = "Mirpur,Dhaka", PhoneNumber = "016000000", Email = "c1@gmail.com" } , new Customer { Id = 2, Name = "Customer -2", SalesPersonId = 1, Address = "JamalPur", PhoneNumber = "015000000", Email = "c2@gmail.com" }, new Customer { Id = 2, Name = "Customer -3", SalesPersonId = 1, Address = "Kamal Pur", PhoneNumber = "01557000" } });
            modelBuilder.Entity<ItemType>().HasData(new List<ItemType> { new ItemType { Id = 1, Name = "Unit" }, new ItemType { Id = 2, Name = "Category" }, new ItemType { Id = 3, Name = "Manufacturer" } });
            modelBuilder.Entity<ItemSetup>().HasData(new List<ItemSetup> { new ItemSetup { Id = 1, Name = "Sample Unit-1", ItemTypeId = 1 }, new ItemSetup { Id=4, Name="Sample Unit-2",ItemTypeId=1},new ItemSetup { Id=2, Name="Sample Category-1",ItemTypeId =2}, new ItemSetup { Id = 5, Name = "Sample Category-2", ItemTypeId = 2 }, new ItemSetup { Id=3, Name= "Sample Manufacturer-1", ItemTypeId=3}, new ItemSetup { Id = 3, Name = "Sample Manufacturer-2", ItemTypeId = 3 } });
            modelBuilder.Entity<Item>().HasData(new List<Item> { new Item { Id = 1, Name = "Sample Item 1",UnitId=1,CategoryId=2,ManufacturerId=3 }, new Item { Id = 2, Name = "Sample Item 2", UnitId = 4, CategoryId = 5, ManufacturerId = 6 }, new Item { Id = 3, Name = "Sample Item 3", UnitId = 1, CategoryId = 2, ManufacturerId = 3 } });
        }
    }
}
