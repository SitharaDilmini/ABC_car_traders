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
    public partial class View_car_details : Form
    {
        private AppDbContext _context;
        private string _userName;
        private Car _car;
        private Main_customer_form _mainUserForm;


        public View_car_details(Car car, string userName, Main_customer_form mainUserForm)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _userName = userName;
            _car = car;
            _mainUserForm = mainUserForm;

            
            if (string.IsNullOrEmpty(car.Image) || !File.Exists(car.Image))
            {
                picBoxCar.Image = null;
            }
            else
            {
                picBoxCar.Image = Image.FromFile(car.Image);
                picBoxCar.SizeMode = PictureBoxSizeMode.Zoom;
            }
            picBoxCar.Tag = car.Image;
            lblMake.Text = $"Car Make: {car.CarMake.Make}";
            lblModel.Text = $"Car Model: {car.CarMake.CarModel.ModelName}";
            lblYear.Text = $"Year: {car.Year.ToString()}";
            lblColor.Text = $"Color: {car.Color}";
            lblTransmission.Text = $"Transmission: {car.Transmission}";
            lblBodyType.Text = $"Body Type: {car.BodyType}";
            lblFuelType.Text = $"Fuel Type: {car.FuelType}";
            lblEngCapacity.Text = $"Engine Capacity: {car.EngineCapacity}";
            lblPrice.Text = $"Price: {car.Price.ToString("N0")}";
            txtOtherFeatures.Text = car.AdditionalFeatures;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Car_order_confirm_form orderConfirmationForm = new Car_order_confirm_form(_userName, _car, _mainUserForm);
            orderConfirmationForm.Owner = this;
            orderConfirmationForm.ShowDialog(); // Use ShowDialog to make it modal
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
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
                var Car = _context.Cars.FirstOrDefault(c => c.Id == _car.Id);
                if (Car == null)
                {
                    MessageBox.Show("Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // if sparepart is already added to the cart
                var cartAddedItem = _context.CartItems.FirstOrDefault(ci => ci.CarId == Car.Id && ci.UserId == user.Id);
                if (cartAddedItem != null)
                {
                    MessageBox.Show("Item already added to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure the CartItem table exists and is properly mapped
                var cartItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    CarId = Car.Id,
                    SparePartId = null,
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

        private void View_car_details_Load(object sender, EventArgs e)
        {

        }
    }
}
