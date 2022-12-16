using ProductsCRUD.Data;
using ProductsCRUD.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ProductsCRUD
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = false;
        }


        private void frmProducts_Load(object sender, EventArgs e)                // load forme
        {
            productsLoad();
            cmbCategories.DataSource = DatabaseConnection.ProductsDB.Categories.ToList();
        }


        private void productsLoad()                                              // load proizvoda 
        {
            dgvProducts.DataSource = DatabaseConnection.ProductsDB.Products.ToList();
        }



        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                   return;

            var id = dgvProducts.Rows[e.RowIndex].Cells[0].Value;
            var product = DatabaseConnection.ProductsDB.Products.Find(id);

            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtQuantity.Text = product.Quantity.ToString();
            cmbCategories.Text = product.Category.Name;
            pbImage.Image = ImageHelper.FromByteToImage(product.Image);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TxtImageClear();

            var newProduct = new frmAddProduct();
            newProduct.ShowDialog();

            productsLoad();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||  string.IsNullOrWhiteSpace(txtQuantity.Text) 
                || pbImage.Image == null)
            {
                MessageBox.Show("Check your input, all fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var product = DatabaseConnection.ProductsDB.Products.Find(int.Parse(txtId.Text));

                product.Name = txtName.Text;
                product.Description = txtDescription.Text;
                product.Quantity = int.Parse(txtQuantity.Text);
                product.Category = cmbCategories.SelectedItem as Category;
                product.Image = ImageHelper.FromImageToByte(pbImage.Image);

                DatabaseConnection.ProductsDB.SaveChanges();

                productsLoad();

                MessageBox.Show("The product was updated successfully.");

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtId.Text))                   // potreban je samo ID za brisanje reda
            {
                MessageBox.Show("Check the ID field, it is required to delete the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete the record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    var id = int.Parse(txtId.Text);
                    var product = DatabaseConnection.ProductsDB.Products.Find(id);

                    DatabaseConnection.ProductsDB.Products.Remove(product);
                    DatabaseConnection.ProductsDB.SaveChanges();

                    productsLoad();

                    MessageBox.Show("The product was deleted successfully.");

                    TxtImageClear();
                }
            }
        }

        private void TxtImageClear()
        {
            txtId.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtQuantity.Clear();
            pbImage.Image = null;
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)   // prikaz slike proizvoda u novoj formi 
        {
            if (dgvProducts.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var imageLoad = new frmImage(dgvProducts.Rows[e.RowIndex].DataBoundItem as Product);
                imageLoad.ShowDialog();
            }
        }
    }
}

