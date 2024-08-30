namespace ProductsCRUD.Data
{
    public class DatabaseConnection
    {
        public static ProductsDBContext ProductsDB { get; set; } = new ProductsDBContext();
    }

}
