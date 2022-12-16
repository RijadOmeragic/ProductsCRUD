using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsCRUD.Data
{
    public class DatabaseConnection
    {
        public static ProductsDBContext ProductsDB { get; set; } = new ProductsDBContext();
    }

}
