using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCRUD.Data
{
    [Table("Products")]

    public class Product
    {
        public int Id { get; set; }                      
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        public virtual Category Category  { get; set; }
    }
}
