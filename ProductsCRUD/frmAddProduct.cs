using ProductsCRUD.Data;
using ProductsCRUD.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace ProductsCRUD
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
            cmbCategories.DataSource = DatabaseConnection.ProductsDB.Categories.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) || pbImage.Image == null)
            {

                MessageBox.Show("Check your input, all fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var product = new Product()
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Category = cmbCategories.SelectedItem as Category,
                    Image = ImageHelper.FromImageToByte(pbImage.Image)
                };

                DatabaseConnection.ProductsDB.Products.Add(product);
                DatabaseConnection.ProductsDB.SaveChanges();

                MessageBox.Show("The product was added successfully.");

                Close();
            }
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
