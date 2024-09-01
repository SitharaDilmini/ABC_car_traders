using ABC_Car_Traders.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ABC_Car_Traders.Models;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Text;
using System.Linq.Expressions;
using System.Globalization;
using ABC_car_traders.Models;

namespace ABC_Car_Traders
{
    public partial class Main_customer_form : Form
    {
        private AppDbContext _context;
        private string _userName;


        public Main_customer_form(string userName)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _userName = userName;
            lblWelcome.Text = $"Welcome, {_userName}!";

            cmbCarMake.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbCarModel.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbCarYear.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbCarColor.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbCarBodyType.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbCarFuelType.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbMaxPrice.SelectedIndexChanged += ComboBox_SelectedIndexChanged;


            pnlLoadUserSelections.AutoScroll = true; // Enable auto scroll for the panel
            pnlSprPartCategories.AutoScroll = true; // Enable auto scroll for the panel


        }

        private void Main_user_form_Load(object sender, EventArgs e)
        {
            
            pnlSpareParts.Visible = false;
            pnlMyCart.Visible = false;
            pnlCars.Visible = true;
            pnlMyProfile.Visible = false;

            pnlPendingOrders.Visible = true;
            pnlProcessingOrders.Visible = false;
            pnlCompletedOrders.Visible = false;

            LoadCarMake();
            LoadCarModel();
            LoadCarYear();
            LoadCarColor();
            LoadCarBodyType();
            LoadCarFuelType();
            LoadCarMaxPrice();

            List<CarSparePart> spareParts = _context.CarSpareParts.ToList(); // Fetch the spare parts from your database
            DisplaySpareParts(spareParts);

            UpdateCartQuantity();

            ShowUserDetailsInMyProfile();



            DisplayPendingOrders();
            DisplayProcessingOrders();
            DisplayCompletedOrders();

            GetPendingOrdersNo();
            GetProcessingOrdersNo();
            GetCompletedOrdersNo();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserSelections();
        }

        public void ClearFields()
        {
            cmbCarMake.SelectedIndex = 0;
            cmbCarModel.SelectedIndex = 0;
            cmbCarYear.SelectedIndex = 0;
            cmbCarColor.SelectedIndex = 0;
            cmbCarBodyType.SelectedIndex = 0;
            cmbMaxPrice.SelectedIndex = 0;
        }


        //----------------------------- Handle ComboBoxes -----------------------------
        //-----------------------------------------------------------------------------
        private void cmb_drawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (e.Index < 0) return;

            e.DrawBackground();
            string text = comboBox.Items[e.Index].ToString();
            e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }
        private void cmb_dropDown(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Items.Contains("--SELECT--"))
            {
                comboBox.Items.Remove("--SELECT--");
            }
        }
        private void cmb_dropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Items.Insert(0, "--SELECT--");
                comboBox.SelectedIndex = 0;
            }
        }



        //----------------------------- Handle Side Menu Section ------------------------------
        //-------------------------------------------------------------------------------------
        private void btn_srh_car_select_Click(object sender, EventArgs e)
        {
            pnlCars.Visible = true;
            pnlSpareParts.Visible = false;
            pnlMyCart.Visible = false;
            pnlMyProfile.Visible = false;
            UpdateButtonColors(btnSrchCarSelect);
        }
        private void btn_car_parts_select_Click(object sender, EventArgs e)
        {
            pnlSpareParts.Visible = true;
            pnlCars.Visible = false;
            pnlMyCart.Visible = false;
            pnlMyProfile.Visible = false;
            UpdateButtonColors(btnCarPartsSelect);
        }
        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            pnlMyProfile.Visible = true;
            pnlMyCart.Visible = false;
            pnlCars.Visible = false;
            pnlSpareParts.Visible = false;
        }
        private void UpdateButtonColors(Button selectedButton)
        {
            btnSrchCarSelect.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCarPartsSelect.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);

            selectedButton.BackColor = System.Drawing.Color.Silver;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
        private void ShowLoginForm()
        {
            login_form login_Form = new login_form();
            login_Form.Show();
            this.Hide();
        }




        //----------------------------- Handle Search Cars Section -----------------------------
        //--------------------------------------------------------------------------------------
        private void LoadCarMake()
        {
            var carMakes = _context.CarMakes.Select(cm => cm.Make).Distinct().ToList();

            cmbCarMake.Items.Clear();
            cmbCarMake.Items.Add("--SELECT--");
            cmbCarMake.Items.AddRange(carMakes.ToArray());
            cmbCarMake.SelectedIndex = 0;
        }
        private void LoadCarModel()
        {
            var carModels = _context.CarModels.Select(cm => cm.ModelName).Distinct().ToList();

            cmbCarModel.Items.Clear();
            cmbCarModel.Items.Add("--SELECT--");
            cmbCarModel.Items.AddRange(carModels.ToArray());
            cmbCarModel.SelectedIndex = 0;
        }
        private void LoadCarYear()
        {
            var carYears = _context.Cars.Select(c => c.Year).Distinct().ToList();
            cmbCarYear.Items.Clear();
            cmbCarYear.Items.Add("--SELECT--");
            foreach (var year in carYears)
            {
                cmbCarYear.Items.Add(year.ToString());
            }
            cmbCarYear.SelectedIndex = 0;
        }
        private void LoadCarColor()
        {
            var carColors = _context.Cars.Select(c => c.Color).Distinct().ToList();
            cmbCarColor.Items.Clear();
            cmbCarColor.Items.Add("--SELECT--");
            cmbCarColor.Items.AddRange(carColors.ToArray());
            cmbCarColor.SelectedIndex = 0;
        }
        public void LoadCarBodyType()
        {
            var carBodyTypes = _context.Cars.Select(c => c.BodyType).Distinct().ToList();
            cmbCarBodyType.Items.Clear();
            cmbCarBodyType.Items.Add("--SELECT--");
            cmbCarBodyType.Items.AddRange(carBodyTypes.ToArray());
            cmbCarBodyType.SelectedIndex = 0;
        }
        private void LoadCarFuelType()
        {
            var carFuelTypes = _context.Cars.Select(c => c.FuelType).Distinct().ToList();
            cmbCarFuelType.Items.Clear();
            cmbCarFuelType.Items.Add("--SELECT--");
            cmbCarFuelType.Items.AddRange(carFuelTypes.ToArray());
            cmbCarFuelType.SelectedIndex = 0;
        }
        private void LoadCarMaxPrice()
        {
            var predefinedPrices = new List<string>
            {
                "4000000",
                "5000000",
                "6000000",
                "7000000",
                "8000000",
                "9000000",
                "10000000",
            };

            cmbMaxPrice.Items.Clear();
            cmbMaxPrice.Items.Add("--SELECT--");
            cmbMaxPrice.Items.AddRange(predefinedPrices.ToArray());
            cmbMaxPrice.SelectedIndex = 0;
        }

        // Reset the search filters
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        // Get selected filters
        private (string make, string model, int year, string color, string bodyType, string fuelType, int price) GetSelectedFilters()
        {
            return (
                cmbCarMake.SelectedItem?.ToString() == "--SELECT--" ? null : cmbCarMake.SelectedItem?.ToString(),
                cmbCarModel.SelectedItem?.ToString() == "--SELECT--" ? null : cmbCarModel.SelectedItem?.ToString(),
                int.TryParse(cmbCarYear.SelectedItem?.ToString(), out int year) ? year : 0,
                cmbCarColor.SelectedItem?.ToString() == "--SELECT--" ? null : cmbCarColor.SelectedItem?.ToString(),
                cmbCarBodyType.SelectedItem?.ToString() == "--SELECT--" ? null : cmbCarBodyType.SelectedItem?.ToString(),
                cmbCarFuelType.SelectedItem?.ToString() == "--SELECT--" ? null : cmbCarFuelType.SelectedItem?.ToString(),
                int.TryParse(cmbMaxPrice.SelectedItem?.ToString(), out int price) ? price : int.MaxValue
            );
        }

        // Get search results based on the selected filters
        private List<Car> GetSearchResults()
        {
            var filters = GetSelectedFilters();

            var make = filters.make;
            var model = filters.model;
            var year = filters.year;
            var color = filters.color;
            var bodyType = filters.bodyType;
            var fuelType = filters.fuelType;
            var price = filters.price;

            List<Car> result = new List<Car>();

            var cars = _context.Cars.Include("CarMake.CarModel")
                                         .Where(c => c.DeletedDate == null) 
                                         .ToList();
            foreach (var car in cars)
            {
                if (!string.IsNullOrEmpty(make) && car.CarMake.Make != make)
                    continue;

                if (!string.IsNullOrEmpty(model) && car.CarMake.CarModel.ModelName != model)
                    continue;

                if (year != 0 && car.Year != year)
                    continue;

                if (!string.IsNullOrEmpty(color) && car.Color != color)
                    continue;

                if (!string.IsNullOrEmpty(bodyType) && car.BodyType != bodyType)
                    continue;

                if (!string.IsNullOrEmpty(fuelType) && car.FuelType != fuelType)
                    continue;

                if (price != int.MaxValue)
                {
                    if (price != int.MaxValue && car.Price > price)
                        continue;
                }

                result.Add(car);
            }

            return result;
        }

        // Load user selections
        private void LoadUserSelections()
        {
            pnlLoadUserSelections.Controls.Clear();

            var searchResults = GetSearchResults();

            int itemsPerRow = 4;
            int itemWidth = 225;
            int itemHeight = 250;
            int horizontalSpacing = 10;
            int verticalSpacing = 10;

            int xPos = horizontalSpacing;
            int yPos = verticalSpacing;

            for (int i = 0; i < searchResults.Count; i++)
            {
                var car = searchResults[i];

                Guna2Panel carPanel = new Guna2Panel
                {
                    Size = new Size(itemWidth, itemHeight),
                    Location = new Point(xPos, yPos),
                    BorderColor = Color.LightGray,
                    BorderThickness = 0, 
                    BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid 
                };

                PictureBox carPictureBox = new PictureBox
                {
                    Size = new Size(170, 100),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = car.Image 
                };
                carPanel.Controls.Add(carPictureBox);

                Label lblCarMake = new Label
                {
                    Text = $"Make: {car.CarMake.Make}",
                    Location = new Point(10, 120),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                carPanel.Controls.Add(lblCarMake);

                Label lblCarModel = new Label
                {
                    Text = $"Model: {car.CarMake.CarModel.ModelName}",
                    Location = new Point(10, 140),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                carPanel.Controls.Add(lblCarModel);

                Label lblCarYear = new Label
                {
                    Text = $"Year: {car.Year}",
                    Location = new Point(10, 160),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                carPanel.Controls.Add(lblCarYear);

                Label lblPrice = new Label
                {
                    Text = $"Price: {car.Price.ToString("N0")}",
                    Location = new Point(10, 180),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                carPanel.Controls.Add(lblPrice);

                Guna2Button btnViewCarDetails = new Guna2Button
                {
                    Text = "View Details",
                    Size = new Size(170, 30),
                    Location = new Point(10, 205),
                    ForeColor = Color.White,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                    BorderRadius = 4,
                    Cursor = Cursors.Hand,
                    Tag = car 
                };
                btnViewCarDetails.Click += BtnViewCarDetails_Click;
                carPanel.Controls.Add(btnViewCarDetails);

                pnlLoadUserSelections.Controls.Add(carPanel);

                if ((i + 1) % itemsPerRow == 0)
                {
                    xPos = horizontalSpacing;
                    yPos += itemHeight + verticalSpacing;
                }
                else
                {
                    xPos += itemWidth + horizontalSpacing;
                }
            }
        }

        // Display the car details when the View Details button is clicked
        private void BtnViewCarDetails_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is Car car)
            {
                View_car_details viewCarDetailsForm = new View_car_details(car, _userName, this);
                viewCarDetailsForm.ShowDialog();
            }
        }

        // View the My Cart panel
        private void btnMyCart_Click(object sender, EventArgs e)
        {
            GetCartItems(_userName);
            pnlMyCart.Visible = true;
            pnlMyProfile.Visible = false;
        }




       

        //----------------------------- Handle Search Spare Parts Section -----------------------------
        //---------------------------------------------------------------------------------------------
        private void lblEngine_Click_1(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Engine").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblTransmission_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Transmission").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblSuspension_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Suspension").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblBrake_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Brake").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblExhaust_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Exhaust").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblInterior_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Interior").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblExterior_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Exterior").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblPerformance_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Performance").ToList();
            DisplaySpareParts(spareParts);
        }
        private void lblWheels_Click(object sender, EventArgs e)
        {
            List<CarSparePart> spareParts = _context.CarSpareParts.Where(csp => csp.Category == "Wheels").ToList();
            DisplaySpareParts(spareParts);
        }

        // Display spare parts based on the selected category
        private void DisplaySpareParts(List<CarSparePart> spareParts)
        {
            pnlShowSprParts.Controls.Clear();

            int itemsPerRow = 4;
            int itemWidth = 200;
            int itemHeight = 255;
            int horizontalSpacing = 10;
            int verticalSpacing = 10;

            int xPos = horizontalSpacing;
            int yPos = verticalSpacing;

            for (int i = 0; i < spareParts.Count; i++)
            {
                var sparePart = spareParts[i];

                sparePart = _context.CarSpareParts.Where(sp => sp.DateDeletedAt == null).FirstOrDefault(sp => sp.Id == sparePart.Id);

                Guna2Panel sparePartPanel = new Guna2Panel
                {
                    Size = new Size(itemWidth, itemHeight),
                    Location = new Point(xPos, yPos),
                    BorderColor = Color.LightGray,
                    BorderThickness = 1, 
                    BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid 
                };

                PictureBox picSparePart = new PictureBox
                {
                    Size = new Size(180, 100),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    ImageLocation = sparePart.ImagePath 
                };
                sparePartPanel.Controls.Add(picSparePart);

                Label lblPartName = new Label
                {
                    Text = $"Part Name: {sparePart.PartName}",
                    Location = new Point(10, 120),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblPartName);

                Label lblCategory = new Label
                {
                    Text = $"Category: {sparePart.Category}",
                    Location = new Point(10, 140),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblCategory);

                Label lblPrice = new Label
                {
                    Text = $"Price: {sparePart.Price.ToString("C")}",
                    Location = new Point(10, 160),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblPrice);

                Label lblStockQuantity = new Label
                {
                    Text = $"Stock: {sparePart.StockQuantity}",
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Location = new Point(10, 180),
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblStockQuantity);

                Guna2Button btnViewDetails = new Guna2Button
                {
                    Text = "View Details",
                    Size = new Size(180, 30),
                    Location = new Point(10, 205),
                    ForeColor = Color.White,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                    BorderRadius = 4,
                    Cursor = Cursors.Hand,
                    Tag = sparePart 
                };
                btnViewDetails.Click += BtnViewSpPartsDetails_Click;
                sparePartPanel.Controls.Add(btnViewDetails);

                pnlShowSprParts.Controls.Add(sparePartPanel);

                if ((i + 1) % itemsPerRow == 0)
                {
                    xPos = horizontalSpacing;
                    yPos += itemHeight + verticalSpacing;
                }
                else
                {
                    xPos += itemWidth + horizontalSpacing;
                }
            }
        }

        // Display the spare part details when the View Details button is clicked
        private void BtnViewSpPartsDetails_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is CarSparePart sparePart)
            {
                View_spareparts_details viewSparePartDetails = new View_spareparts_details(sparePart, _userName, this);
                viewSparePartDetails.ShowDialog();
            }
        }

        // View the My Cart panel
        private void btnMyCart2_Click(object sender, EventArgs e)
        {
            GetCartItems(_userName);
            pnlMyCart.Visible = true;
            pnlMyProfile.Visible = false;
        }




        //----------------------------- Handle Cart Section -----------------------------
        //-------------------------------------------------------------------------------
        private void DisplayCartItems(List<CartItem> cartItems)
        {
            pnlShowCartItems.Controls.Clear();

            int itemsPerRow = 2;
            int itemWidth = 430; 
            int itemHeight = 150;
            int horizontalSpacing = 20;
            int verticalSpacing = 20;

            int xPos = horizontalSpacing;
            int yPos = verticalSpacing;

            for (int i = 0; i < cartItems.Count; i++)
            {
                var cartItem = cartItems[i];

                string imagePath = null;
                string itemName = null;
                string itemDescription = null;
                string itemPrice = null;

                if (cartItem.CarId != null)
                {
                    imagePath = cartItem.Car?.Image;
                    itemName = $"Car: {cartItem.Car?.CarMake?.Make} {cartItem.Car?.CarMake?.CarModel?.ModelName}";
                    itemDescription = $"Year: {cartItem.Car?.Year}, Color: {cartItem.Car?.Color}";
                    itemPrice = $"Price: {cartItem.Car?.Price.ToString("C")}";
                }
                else if (cartItem.SparePartId != null)
                {
                    imagePath = cartItem.SparePart?.ImagePath;
                    itemName = $"Spare Part: {cartItem.SparePart?.PartName}";
                    itemDescription = $"Category: {cartItem.SparePart?.Category}";
                    itemPrice = $"Price: {cartItem.SparePart?.Price.ToString("C")}";
                }

                Guna2Panel itemPanel = new Guna2Panel
                {
                    Size = new Size(itemWidth, itemHeight),
                    Location = new Point(xPos, yPos),
                    BorderColor = Color.LightGray,
                    BorderThickness = 1, 
                    BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
                };

                Guna2PictureBox pictureBox = new Guna2PictureBox
                {
                    Size = new Size(160, 125),
                    Location = new Point(10, 10),
                    BorderStyle = BorderStyle.None,
                    ImageLocation = imagePath, 
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                itemPanel.Controls.Add(pictureBox);

                Label lblItemName = new Label
                {
                    Text = itemName,
                    Location = new Point(190, 10),
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true
                };
                itemPanel.Controls.Add(lblItemName);

                Label lblItemDescription = new Label
                {
                    Text = itemDescription,
                    Location = new Point(190, 35),
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true
                };
                itemPanel.Controls.Add(lblItemDescription);

                Label lblItemPrice = new Label
                {
                    Text = itemPrice,
                    Location = new Point(190, 60),
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true
                };
                itemPanel.Controls.Add(lblItemPrice);

                Guna2Button btnViewDetails = new Guna2Button
                {
                    Text = "View Details",
                    Size = new Size(100, 30),
                    Location = new Point(194, 105),
                    BorderRadius = 4,
                    FillColor = Color.FromArgb(94, 148, 255),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = cartItem
                };
                btnViewDetails.Click += btnViewDetails_Click;
                itemPanel.Controls.Add(btnViewDetails);

                Guna2Button btnOrder = new Guna2Button
                {
                    Text = "Order",
                    Size = new Size(100, 30),
                    Location = new Point(305, 105),
                    BorderRadius = 4,
                    FillColor = Color.FromArgb(64, 64, 64),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = cartItem 
                };
                btnOrder.Click += btnOrder_Click;
                itemPanel.Controls.Add(btnOrder);

                Guna2ImageButton btnDelete = new Guna2ImageButton
                {
                    Size = new Size(25, 25),
                    Location = new Point(400, 10),
                    Image = Image.FromFile(@"D:\Esoft\Top Up\AD\Coursework 1 - project\images\delete.png"),
                    ImageSize = new Size(20, 20),
                    Cursor = Cursors.Hand,
                    HoverState = {
                        Image = Image.FromFile(@"D:\Esoft\Top Up\AD\Coursework 1 - project\images\delete.png"),
                        ImageSize = new Size(21, 21),
                    },
                    PressedState = {
                        Image = Image.FromFile(@"D:\Esoft\Top Up\AD\Coursework 1 - project\images\delete.png"),
                        ImageSize = new Size(21, 21),
                    },
                    Tag = cartItem
                };
                btnDelete.Click += btnDelete_Click;
                itemPanel.Controls.Add(btnDelete);

                pnlShowCartItems.Controls.Add(itemPanel);

                if ((i + 1) % itemsPerRow == 0)
                {
                    xPos = horizontalSpacing;
                    yPos += itemHeight + verticalSpacing;
                }
                else
                {
                    xPos += itemWidth + horizontalSpacing;
                }
            }
        }

        // Display the selected item's details when the View Details button is clicked
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is CartItem cartItem)
            {
                if (cartItem.SparePart != null)
                {
                    View_spareparts_details viewSparePartDetails = new View_spareparts_details(cartItem.SparePart, _userName, this);
                    viewSparePartDetails.ShowDialog();
                }
                else if (cartItem.Car != null)
                {
                    View_car_details viewCarDetails = new View_car_details(cartItem.Car, _userName, this);
                    viewCarDetails.ShowDialog();
                }
            }
        }

        // Display the order confirmation forms when the Order button is clicked
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is CartItem cartItem)
            {
                if (cartItem.SparePart != null)
                {
                    Spareparts_order_confirm_form spOrderConfirmationForm = new Spareparts_order_confirm_form(_userName, cartItem.SparePart, this);
                    spOrderConfirmationForm.ShowDialog();
                }
                else if (cartItem.Car != null)
                {
                    Car_order_confirm_form carOrderConfirmationForm = new Car_order_confirm_form(_userName, cartItem.Car, this);
                    carOrderConfirmationForm.ShowDialog();
                }
            }
        }

        // get cartItems from the database related to logged user
        private void GetCartItems(string userName)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Name == userName);

                if (user == null)
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cartItems = _context.CartItems
                                        .Include(ci => ci.Car)
                                        .Include(ci => ci.Car.CarMake.CarModel)
                                        .Include(ci => ci.SparePart)
                                        .Include(ci => ci.SparePart.CarMake.CarModel)
                                        .Where(ci => ci.UserId == user.Id)
                                        .ToList();

                DisplayCartItems(cartItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle the delete button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (sender is Guna2ImageButton button && button.Tag is CartItem cartItem)
            {
                try
                {
                    var result = MessageBox.Show("Are you sure you want to remove this item from the cart?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var itemToRemove = _context.CartItems.FirstOrDefault(ci => ci.Id == cartItem.Id);
                        if (itemToRemove != null)
                        {
                            _context.CartItems.Remove(itemToRemove);
                            _context.SaveChanges();
                            MessageBox.Show("Item removed from the cart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the cart items display
                            GetCartItems(_userName);
                            UpdateCartQuantity();
                        }
                        else
                        {
                            MessageBox.Show("Item not found in the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the item from the cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        // Update the cart quantity
        private void UpdateCartQuantity()
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
            if (user == null)
                return;

            int cartItemCount = _context.CartItems.Count(ci => ci.UserId == user.Id);
            txtCartQuantity2.Text = cartItemCount.ToString();
            txtCartQuantity.Text = cartItemCount.ToString();
        }




        //----------------------------- Handle My Profile Section -----------------------------
        //-------------------------------------------------------------------------------------
        private void ShowUserDetailsInMyProfile()
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
            if (user != null)
            {
                lblUserName.Text = user.Name;
                txtUserName.Text = user.Name;
                txtUserEmail.Text = user.Email;
                txtUserPhone.Text = user.Phone;
                lblCreatedDate.Text = $"Created At: {user.CreatedDate.ToShortDateString()}";
            }
        }

        // PENDING ORDERS
        private void btnPendingOrders_Click(object sender, EventArgs e)
        {
            pnlPendingOrders.Visible = true;
            pnlProcessingOrders.Visible = false;
            pnlCompletedOrders.Visible = false;
        }
        private void picPendingOrders_Click(object sender, EventArgs e)
        {
            pnlPendingOrders.Visible = true;
            pnlProcessingOrders.Visible = false;
            pnlCompletedOrders.Visible = false;
        }

        // Get the number of pending orders
        public void GetPendingOrdersNo()
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
            var orderCount = _context.Orders.Count(o => o.Status == "Pending" && o.UserId == user.Id);


            if (orderCount > 0)
            {
                lblPendingOrdersNo.Text = orderCount.ToString();
            }
            else
            {
                lblPendingOrdersNo.Text = "0";
            }
        }

        // Display the pending orders
        public void DisplayPendingOrders()
        {
            pnlDisplayPendingOrders.Controls.Clear();

            int itemWidth = 480;
            int itemHeight = 140;
            int horizontalSpacing = 5;
            int verticalSpacing = 5;

            int xPos = horizontalSpacing;
            int yPos = verticalSpacing;

            try
            {
                if (_context == null)
                {
                    MessageBox.Show("Database context is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(_userName))
                {
                    MessageBox.Show("User name is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
                if (user == null)
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var pendingOrders = _context.Orders
                    .Include(o => o.User)
                    .Where(o => o.Status == "Pending" && o.UserId == user.Id)
                    .ToList();

                if (!pendingOrders.Any())
                {
                    Label lblNoOrders = new Label
                    {
                        Text = "No pending orders.",
                        Location = new Point(xPos, yPos),
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    pnlDisplayPendingOrders.Controls.Add(lblNoOrders);
                    return;
                }

                foreach (var order in pendingOrders)
                {
                    if (order.Car != null || order.CarSparePart != null)
                    {
                        var car = order.Car;
                        var sparePart = order.CarSparePart;

                        Guna2Panel orderPanel = new Guna2Panel
                        {
                            Size = new Size(itemWidth, itemHeight),
                            Location = new Point(xPos, yPos),
                            BorderColor = Color.LightGray,
                            BorderThickness = 1,
                            BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
                        };

                        Label lblOrderType = new Label
                        {
                            Text = car != null ? "Car Order" : "Spare Part Order",
                            Location = new Point(10, 10),
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblOrderType);

                        PictureBox carPictureBox = new PictureBox
                        {
                            Size = new Size(100, 75),
                            Location = new Point(10, 40),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            ImageLocation = car != null ? car.Image : sparePart.ImagePath
                        };
                        orderPanel.Controls.Add(carPictureBox);

                        Label lblCarDetails = new Label
                        {
                            Text = car != null ? $"Car: {car.CarMake.Make} {car.CarMake.CarModel.ModelName}\nYear: {car.Year}\nPrice: Rs. {car.Price:N2}" : $"Spare Part: {sparePart.PartName}\nPrice: Rs. {sparePart.Price:N2}",
                            Location = new Point(120, 40),
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblCarDetails);

                        Label lblOrderDate = new Label
                        {
                            Text = $"Order Date: {order.CreatedDate.ToShortDateString()}",
                            Location = new Point(120, 98),
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblOrderDate);

                        Guna2Button btnCancelOrder = new Guna2Button
                        {
                            Text = "Cancel Order",
                            Size = new Size(100, 30),
                            Location = new Point(360, 88),
                            BorderRadius = 4,
                            FillColor = Color.DimGray,
                            ForeColor = Color.White,
                            Cursor = Cursors.Hand,
                            Tag = order
                        };
                        btnCancelOrder.Click += btnCancelOrder_Click;
                        orderPanel.Controls.Add(btnCancelOrder);

                        pnlDisplayPendingOrders.Controls.Add(orderPanel);

                        yPos += itemHeight + verticalSpacing;
                    }                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while displaying the pending orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Refresh the pending orders display
        public void RefreshPendingOrders()
        {
            DisplayPendingOrders();
        }

        // Cancel the selected order
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Cast the sender to a Guna2Button and retrieve the associated order
                var btnCancelOrder = sender as Guna2Button;
                var order = btnCancelOrder?.Tag as Order;

                if (order != null)
                {
                    // Update the order status to "Cancelled"
                    order.Status = "Cancelled";

                    // Save changes to the database
                    _context.SaveChanges();

                    // Optionally, you can notify the user of the successful cancellation
                    MessageBox.Show("Order has been cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the pending orders display to reflect the changes
                    RefreshPendingOrders();
                }
                else
                {
                    MessageBox.Show("Unable to retrieve order details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while cancelling the order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // PROCESSING ORDERS
        private void btnProcessingOrders_Click(object sender, EventArgs e)
        {
            pnlPendingOrders.Visible = false;
            pnlProcessingOrders.Visible = true;
            pnlCompletedOrders.Visible = false;
        }
        private void picProcessingOrders_Click(object sender, EventArgs e)
        {
            pnlPendingOrders.Visible = false;
            pnlProcessingOrders.Visible = true;
            pnlCompletedOrders.Visible = false;
        }

        // Get the number of processing orders
        public void GetProcessingOrdersNo()
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
            var orderCount = _context.Orders.Count(o => o.Status != "Pending" && o.Status != "Complete" && o.Status != "Cancelled" && o.UserId == user.Id);

            if (orderCount > 0)
            {
                lblProcessingOrdersNo.Text = orderCount.ToString();
            }
            else
            {
                lblProcessingOrdersNo.Text = "0";
            }
        }

        // Display processing orders
        public void DisplayProcessingOrders()
        {
            pnlDisplayProcessingOrders.Controls.Clear();

            int itemWidth = 480;
            int itemHeight = 140;
            int horizontalSpacing = 5;
            int verticalSpacing = 5;

            int xPos = horizontalSpacing;
            int yPos = verticalSpacing;

            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Name == _userName);

                var processingOrders = _context.Orders
                    .Include(o => o.User)
                    .Where(o => o.Status != "Pending" && o.Status != "Complete" && o.Status != "Cancelled" && o.UserId == user.Id)
                    .ToList();

                if (!processingOrders.Any())
                {
                    Label lblNoOrders = new Label
                    {
                        Text = "No processing orders.",
                        Location = new Point(xPos, yPos),
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    pnlDisplayProcessingOrders.Controls.Add(lblNoOrders);
                    return;
                }

                foreach (var order in processingOrders)
                {
                    if (order.Car != null || order.CarSparePart != null)
                    {
                        var car = order.Car;
                        var sparePart = order.CarSparePart;

                        Guna2Panel orderPanel = new Guna2Panel
                        {
                            Size = new Size(itemWidth, itemHeight),
                            Location = new Point(xPos, yPos),
                            BorderColor = Color.LightGray,
                            BorderThickness = 1,
                            BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
                        };

                        Label lblOrderType = new Label
                        {
                            Text = car != null ? "Car Order" : "Spare Part Order",
                            Location = new Point(10, 10),
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblOrderType);

                        PictureBox carPictureBox = new PictureBox
                        {
                            Size = new Size(100, 75),
                            Location = new Point(10, 40),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            ImageLocation = car != null ? car.Image : sparePart.ImagePath
                        };
                        orderPanel.Controls.Add(carPictureBox);

                        Label lblCarDetails = new Label
                        {
                            Text = car != null ? $"Car: {car.CarMake.Make} {car.CarMake.CarModel.ModelName}\nYear: {car.Year}\nPrice: Rs. {car.Price:N2}" : $"Spare Part: {sparePart.PartName}\nPrice: Rs. {sparePart.Price:N2}",
                            Location = new Point(120, 40),
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblCarDetails);

                        Label lblOrderDate = new Label
                        {
                            Text = $"Order Date: {order.CreatedDate.ToShortDateString()}",
                            Location = new Point(120, 98),
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblOrderDate);

                        Guna2Button btnReceivedOrder = new Guna2Button
                        {
                            Text = "Order Recieved",
                            Size = new Size(130, 30),
                            Location = new Point(340, 88),
                            BorderRadius = 4,
                            FillColor = Color.DimGray,
                            ForeColor = Color.White,
                            Cursor = Cursors.Hand,
                            Tag = order
                        };
                        btnReceivedOrder.Click += btnReceivedOrder_Click;
                        orderPanel.Controls.Add(btnReceivedOrder);

                        pnlDisplayProcessingOrders.Controls.Add(orderPanel);

                        yPos += itemHeight + verticalSpacing;
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while displaying the processing orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }


        public void RefreshProcessingOrders()
        {
            DisplayProcessingOrders();
        }


        private void btnReceivedOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var btnReceivedOrder = sender as Guna2Button;
                var order = btnReceivedOrder?.Tag as Order;

                if (order != null)
                {
                    order.Status = "Complete";
                    _context.SaveChanges();

                    MessageBox.Show("Order has been marked as received successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshProcessingOrders();
                }
                else
                {
                    MessageBox.Show("Unable to retrieve order details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // COMPLETED ORDERS
        private void btnCompleteOrders_Click(object sender, EventArgs e)
        {
            pnlCompletedOrders.Visible = true;
            pnlPendingOrders.Visible = false;
            pnlProcessingOrders.Visible = false;
        }

        private void picCompletedOrders_Click(object sender, EventArgs e)
        {
            pnlCompletedOrders.Visible = true;
            pnlPendingOrders.Visible = false;
            pnlProcessingOrders.Visible = false;
        }

        // Get the number of completed orders
        public void GetCompletedOrdersNo()
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == _userName);
            var orderCount = _context.Orders.Count(o => o.Status == "Complete" && o.UserId == user.Id);

            if (orderCount > 0)
            {
                lblCompletedOrdersNo.Text = orderCount.ToString();
            }
            else
            {
                lblCompletedOrdersNo.Text = "0";
            }
        }

        public void DisplayCompletedOrders()
        {

            pnlDisplayCompletedOrders.Controls.Clear();

            int itemWidth = 480;
            int itemHeight = 140;
            int horizontalSpacing = 5;
            int verticalSpacing = 5;

            int xPos = horizontalSpacing;
            int yPos = verticalSpacing;

            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Name == _userName);

                //var completedCarOrders = _context.CarOrders
                //    .Include(co => co.Car)
                //    .Include(co => co.User)
                //    .Where(co => co.Status != "Pending" && co.Status != "Processing" && co.Status != "Cancelled" && co.UserId == user.Id)
                //    .ToList();

                //var completedSparePartOrders = _context.SparePartOrders
                //    .Include(spo => spo.CarSparePart)
                //    .Include(spo => spo.User)
                //    .Where(spo => spo.Status != "Pending" && spo.Status != "Processing" && spo.Status != "Cancelled" && spo.UserId == user.Id)
                //    .ToList();

                var completedCarOrders = _context.Orders
                    .Include(o => o.Car)
                    .Include(o => o.User)
                    .Where(o => o.Status == "Complete" && o.UserId == user.Id)
                    .ToList();

                if (!completedCarOrders.Any())
                {
                    Label lblNoOrders = new Label
                    {
                        Text = "No completed orders.",
                        Location = new Point(xPos, yPos),
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    pnlDisplayCompletedOrders.Controls.Add(lblNoOrders);
                    return;
                }

                foreach (var order in completedCarOrders)
                {
                    var car = order.Car;

                    Guna2Panel orderPanel = new Guna2Panel
                    {
                        Size = new Size(itemWidth, itemHeight),
                        Location = new Point(xPos, yPos),
                        BorderColor = Color.LightGray,
                        BorderThickness = 1,
                        BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
                    };

                    Label lblOrderType = new Label
                    {
                        Text = "Car Order",
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        AutoSize = true
                    };
                    orderPanel.Controls.Add(lblOrderType);

                    PictureBox carPictureBox = new PictureBox
                    {
                        Size = new Size(100, 75),
                        Location = new Point(10, 40),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        ImageLocation = car.Image
                    };
                    orderPanel.Controls.Add(carPictureBox);

                    Label lblCarDetails = new Label
                    {
                        Text = $"Car: {car.CarMake.Make} {car.CarMake.CarModel.ModelName}\nYear: {car.Year}\nPrice: Rs. {car.Price:N2}",
                        Location = new Point(120, 40),
                        Font = new Font("Segoe UI", 10, FontStyle.Regular),
                        AutoSize = true
                    };
                    orderPanel.Controls.Add(lblCarDetails);

                    Label lblOrderDate = new Label
                    {
                        Text = $"Ordered Date: {order.CreatedDate.ToShortDateString()}",
                        Location = new Point(120, 98),
                        Font = new Font("Segoe UI", 10, FontStyle.Regular),
                        AutoSize = true
                    };
                    orderPanel.Controls.Add(lblOrderDate);

                    pnlDisplayCompletedOrders.Controls.Add(orderPanel);

                    yPos += itemHeight + verticalSpacing;
                }

                foreach (var order in completedCarOrders)
                {
                    var sparePart = order.CarSparePart;

                    Guna2Panel orderPanel = new Guna2Panel
                    {
                        Size = new Size(itemWidth, itemHeight),
                        Location = new Point(xPos, yPos),
                        BorderColor = Color.LightGray,
                        BorderThickness = 1,
                        BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
                    };

                    Label lblOrderType = new Label
                    {
                        Text = "Spare Part Order",
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        AutoSize = true
                    };
                    orderPanel.Controls.Add(lblOrderType);

                    PictureBox sparePartPictureBox = new PictureBox
                    {
                        Size = new Size(100, 75),
                        Location = new Point(10, 40),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        ImageLocation = sparePart.ImagePath
                    };
                    orderPanel.Controls.Add(sparePartPictureBox);

                    Label lblSparePartDetails = new Label
                    {
                        Text = $"Part: {sparePart.PartName}\nQuantity: {order.Quantity}\nPrice: Rs. {(sparePart.Price * order.Quantity):N2}",
                        Location = new Point(120, 40),
                        Font = new Font("Segoe UI", 10, FontStyle.Regular),
                        AutoSize = true
                    };
                    orderPanel.Controls.Add(lblSparePartDetails);

                    Label lblOrderDate = new Label
                    {
                        Text = $"Ordered Date: {order.CreatedDate.ToShortDateString()}",
                        Location = new Point(120, 98),
                        Font = new Font("Segoe UI", 10, FontStyle.Regular),
                        AutoSize = true
                    };
                    orderPanel.Controls.Add(lblOrderDate);

                    pnlDisplayCompletedOrders.Controls.Add(orderPanel);

                    yPos += itemHeight + verticalSpacing;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while displaying the processing orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshCompletedOrders()
        {
            DisplayCompletedOrders();
        }


    }

}