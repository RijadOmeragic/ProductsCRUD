using ProductsCRUD.Data;
using ProductsCRUD.Helpers;
using System;
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
