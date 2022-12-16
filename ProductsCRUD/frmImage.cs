using ProductsCRUD.Data;
using ProductsCRUD.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsCRUD
{
    public partial class frmImage : Form
    {
        Product product;

        public frmImage(Product product)
        {
            InitializeComponent();
            this.product = product;
        }

        private void frmImage_Load(object sender, EventArgs e)
        {
            pbImage.Image = ImageHelper.FromByteToImage(product.Image);
        }
    }
}
