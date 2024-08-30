using System.Data.Entity;




namespace ProductsCRUD.Data
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext() : base("DatabasePath")
        {
          
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
