using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ProductsCRUD.Data
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext() : base("DatabasePath")
        {
        }

        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
