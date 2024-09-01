using ABC_Car_Traders.Data;
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
using ABC_car_traders.Models;

namespace ABC_Car_Traders
{
    public partial class Car_order_confirm_form : Form
    {
        private AppDbContext _context;
        private string _userName;
        private Car _car;
        private Main_customer_form _mainUserForm;


        public Car_order_confirm_form(string userName, Car car, Main_customer_form mainUserForm)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _userName = userName;
            _car = car;
            _mainUserForm = mainUserForm;

        }

        private void order_confirmation_Load(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            pnlThank.Visible = false;

            nudQuantity.Minimum = 1;

            nudQuantity.ValueChanged += new EventHandler(nudQuantity_ValueChanged);

            var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
            if (user != null)
            {
                txtUserName.Text = user.Name;
                txtUserAddress.Text = user.Address;
                txtUserPhone.Text = user.Phone;              
            }

            if (string.IsNullOrEmpty(_car.Image) || !File.Exists(_car.Image))
            {
                picBoxCar.Image = null;
            }
            else
            {
                picBoxCar.Image = Image.FromFile(_car.Image);
                picBoxCar.SizeMode = PictureBoxSizeMode.Zoom;
            }
            picBoxCar.Tag = _car.Image;
            lblMake.Text = $"Car Make: {_car.CarMake.Make}";
            lblModel.Text = $"Car Model: {_car.CarMake.CarModel.ModelName}";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = true;
            txtUserAddress.Enabled = true;
            txtUserPhone.Enabled = true;

            btnSave.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the user from the database
                var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
                if (user == null)
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the user's details
                user.Name = txtUserName.Text;
                user.Address = txtUserAddress.Text;
                user.Phone = txtUserPhone.Text;

                // Save the changes to the database
                _context.SaveChanges();

                // Provide feedback to the user
                MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable editing
                txtUserName.Enabled = false;
                txtUserAddress.Enabled = false;
                txtUserPhone.Enabled = false;

                btnSave.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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

                // Ensure the spare part exists and check stock availability
                var car = _context.Cars.FirstOrDefault(c => c.Id == _car.Id);
                if (car == null)
                {
                    MessageBox.Show("Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                // Create the order
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    CarId = car.Id,
                    UserId = user.Id,
                    Status = "Pending",
                    Quantity = (int)nudQuantity.Value,
                    TotalAmount = (int)nudQuantity.Value * car.Price,
                    CreatedDate = DateTime.Now,
                    DeletedDate = null
                };

                // Save the order to the database
                _context.Orders.Add(order);
                _context.SaveChanges();

                MessageBox.Show("Order placed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _mainUserForm.RefreshPendingOrders();
                _mainUserForm.GetPendingOrdersNo();

                _mainUserForm.RefreshProcessingOrders();
                _mainUserForm.GetProcessingOrdersNo();

                _mainUserForm.RefreshCompletedOrders();
                _mainUserForm.GetCompletedOrdersNo();

                pnlThank.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTnkPnlClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            int quantity = (int)nudQuantity.Value;
            int price = _car.Price;

            int totalPrice = quantity * price;

            lblPrice.Text = $"Rs. {totalPrice:N2}";
        }
    }
}
