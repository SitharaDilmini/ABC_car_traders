using ABC_Car_Traders.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ABC_Car_Traders.Data;

namespace ABC_Car_Traders
{
    public partial class View_spareparts_details : Form
    {
        private AppDbContext _context;
        private string _userName;
        private CarSparePart _sparePart;
        private Main_customer_form _mainUserForm;

        public View_spareparts_details(CarSparePart sparePart, string userName, Main_customer_form mainUserForm)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _userName = userName;
            _sparePart = sparePart;
            _mainUserForm = mainUserForm;

            if (string.IsNullOrEmpty(sparePart.ImagePath) || !File.Exists(sparePart.ImagePath))
            {
                picBoxSparePart.Image = null;
            }
            else
            {
                picBoxSparePart.Image = Image.FromFile(sparePart.ImagePath);
                picBoxSparePart.SizeMode = PictureBoxSizeMode.Zoom;
            }
            picBoxSparePart.Tag = sparePart.ImagePath;
            lblSpName.Text = $"Name: {sparePart.PartName}";
            lblSpCategory.Text = $"Category: {sparePart.Category}";
            lblSpCarMake.Text = $"Car Make: {sparePart.CarMake.Make}";
            lblSpCarModel.Text = $"Car Model: {sparePart.CarMake.CarModel.ModelName}";
            lblSpManufracturer.Text = $"Manufacturer: {sparePart.Manufacturer}";
            lblSpWarranty.Text = $"Warranty Period: {sparePart.WarrantyPeriod}";
            lblSpQuantity.Text = $"Stock Quantity: {sparePart.StockQuantity}";
            lblSpPrice.Text = $"Price: {sparePart.Price.ToString("N0")}";
            txtSpDescription.Text = sparePart.Description;
            _mainUserForm = mainUserForm;
        }

        private void View_spareparts_details_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Spareparts_order_confirm_form orderConfirmationForm = new Spareparts_order_confirm_form(_userName, _sparePart, _mainUserForm);
            orderConfirmationForm.Owner = this;
            orderConfirmationForm.ShowDialog();
        }

        // Save in CartItems table
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the user exists
                var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
                if (user == null)
                {
                    MessageBox.Show("User not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure the spare part exists
                var sparePart = _context.CarSpareParts.FirstOrDefault(sp => sp.Id == _sparePart.Id);
                if (sparePart == null)
                {
                    MessageBox.Show("Spare part not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // if sparepart is already added to the cart
                var cartAddedItem = _context.CartItems.FirstOrDefault(ci => ci.SparePartId == sparePart.Id && ci.UserId == user.Id);
                if (cartAddedItem != null)
                {
                    MessageBox.Show("Item already added to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                // Ensure the CartItem table exists and is properly mapped
                var cartItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    CarId = null,
                    SparePartId = sparePart.Id,
                    UserId = user.Id,
                    CreatedDate = DateTime.Now,
                };

                _context.CartItems.Add(cartItem);
                _context.SaveChanges();

                MessageBox.Show("Item added to the cart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding the item to the cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
