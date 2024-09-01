using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ABC_Car_Traders.Data;
using ABC_Car_Traders.Models;
using ABC_Car_Traders.Utils;
using CrystalDecisions.CrystalReports.Engine;
using Guna.UI2.WinForms;
using Mysqlx.Crud;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;  



namespace ABC_Car_Traders
{
    public partial class Admin_dashboard : Form
    {
        private AppDbContext _context;
        private string _adminName;

        public Admin_dashboard(string adminName)
        {
            InitializeComponent();

            _context = new AppDbContext();
            _adminName = adminName;
            lbl_welcome.Text = $"Welcome, {_adminName}!";

        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
            pnlDashboard.Visible = true;
            pnlMngCars.Visible = false;
            pnlSpareParts.Visible = false;
            pnlCustomerManagement.Visible = false;
            pnlManageOrders.Visible = false;
            pnlGenReports.Visible = false;
            pnlAdminStaff.Visible = false;

            btnUpdateCar.Visible = false;
            btnDeleteCar.Visible = false;

            btnSprPartUpdate.Visible = false;
            btnSprPartDelete.Visible = false;

            DisplayUsers();

            // Initialize the ComboBoxes
            InitializeComboBox(cmbCarFuelTyp, new List<string>
            {
                "Petrol (Gasoline)",
                "Diesel",
                "Electric",
                "Hybrid"
            });

            InitializeComboBox(cmbCarBodyTyp, new List<string>
            {
                "Sedan",
                "SUV",
                "Hatchback",
                "Coupe",
                "Convertible",
                "Wagon",
                "Minivan",
                "Van",
                "Crossover",
                "Compact",
                "Luxury"
            });

            InitializeComboBox(cmbCarTransmission, new List<string>
            {
                "Automatic",
                "Manual",
                "Semi-Automatic",
                "CVT"
            });

            InitializeComboBox(cmbSprPartCategory, new List<string>
            {
                "Engine",
                "Transmission",
                "Suspension",
                "Brakes",
                "Exhaust",
                "Interior",
                "Exterior",
                "Performance",
                "Wheels & Tires"
            });

            InitializeComboBox(cmbSprPartWarrantyPeriod, new List<string>
            {
                "1 Month",
                "3 Months",
                "6 Months",
                "1 Year",
                "2 Years",
                "3 Years",
                "5 Years"
            });

            List<string> carMakes = _context.CarMakes.Select(cm => cm.Make).Distinct().ToList();
            InitializeComboBox(cmbCarMake, carMakes);

            List<string> carModels = _context.CarModels.Select(cm => cm.ModelName).Distinct().ToList();
            InitializeComboBox(cmbCarModel, carModels);

            List<string> spCarMakes = _context.CarMakes.Select(cm => cm.Make).Distinct().ToList();
            InitializeComboBox(cmbSprPartCarMake, spCarMakes);

            List<string> spCarModels = _context.CarModels.Select(cm => cm.ModelName).Distinct().ToList();
            InitializeComboBox(cmbSprPartCarModel, spCarModels);

            // Add event handlers to pass selected items to text boxes
            cmbCarMake.SelectedIndexChanged += cmbCarMake_SelectedIndexChanged;
            cmbCarModel.SelectedIndexChanged += cmbCarModel_SelectedIndexChanged;
            cmbSprPartCarMake.SelectedIndexChanged += cmbSprPartCarMake_SelectedIndexChanged;
            cmbSprPartCarModel.SelectedIndexChanged += cmbSprPartCarModel_SelectedIndexChanged;

            // Configure OpenFileDialog
            ofdCarImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofdCarImage.Title = "Select a Car Image";

            ofdSprPartImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofdSprPartImage.Title = "Select a Spare Part Image";

            DisplayCars();
            DisplaySpareParts();

            SetupTableLayoutPanelHeaders();

            SetupTableWithRowsAndSeparators();

            LoadDummyData();
        }

        private void ClearFields()
        {
            txtCarMake.Text = "";
            txtCarModel.Text = "";
            txtCarYear.Text = "";
            txtCarColor.Text = "";
            txtCarEnCpcty.Text = "";
            txtCarPrice.Text = "";
            txtEngNo.Text = "";
            TxtChasNo.Text = "";
            cmbCarBodyTyp.SelectedIndex = -1;
            cmbCarFuelTyp.SelectedIndex = -1;
            cmbCarTransmission.SelectedIndex = -1;
            picCarImg.Image = null;
            picCarImg.Tag = null; // Clear the tag to avoid using old paths
            txtCarAddiFeatures.Text = "";
            txtSprPartName.Clear();
            cmbSprPartCategory.SelectedIndex = -1;
            cmbSprPartCarMake.SelectedIndex = -1;
            cmbSprPartCarModel.SelectedIndex = -1;
            txtSprPartCarMake.Text = "";
            txtSprPartCarModel.Text = "";
            txtSprPartManufacturer.Clear();
            txtSprPartDescription.Clear();
            cmbSprPartWarrantyPeriod.SelectedIndex = -1;
            nudSprPartQuantity.Value = 0;
            txtSprPartPrice.Clear();
            pictureBoxSpareParts.Image = null;
            pictureBoxSpareParts.Tag = null; // Clear the tag to avoid using old paths
            txtCusName.Text = "";
            txtCusEmail.Text = "";
            txtCusPhone.Text = "";
            pbItem.Image = null;
            lblCustomerName.Text = "";
            lblCustomerPhone.Text = "";
            lblCustomerAddress.Text = "";
            lblItemName.Text = "";
            lblQuantity.Text = "";
        }



        //------------------------------- Side Menu Handling -------------------------------
        //----------------------------------------------------------------------------------
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            pnlDashboard.Visible = true;
            pnlMngCars.Visible = false;
            pnlSpareParts.Visible = false;
            pnlCustomerManagement.Visible = false;
            pnlManageOrders.Visible = false;
            pnlGenReports.Visible = false;
            pnlAdminStaff.Visible = false;
            UpdateButtonColors(btnDashboard);
        }
        private void btn_mng_cars_Click(object sender, EventArgs e)
        {
            pnlMngCars.Visible = true;
            pnlDashboard.Visible = false;
            pnlSpareParts.Visible = false;
            pnlCustomerManagement.Visible = false;
            pnlManageOrders.Visible = false;
            pnlGenReports.Visible = false;
            pnlAdminStaff.Visible = false;
            UpdateButtonColors(btnMngCars);
        }
        private void btn_mng_sparts_Click(object sender, EventArgs e)
        {
            pnlSpareParts.Visible = true;
            pnlMngCars.Visible = false;
            pnlCustomerManagement.Visible = false;
            pnlDashboard.Visible = false;
            pnlManageOrders.Visible = false;
            pnlGenReports.Visible = false;
            pnlAdminStaff.Visible = false;
            UpdateButtonColors(btnMngSparts);
        }
        private void btn_mng_cus_Click(object sender, EventArgs e)
        {
            pnlCustomerManagement.Visible = true;
            pnlMngCars.Visible = false;
            pnlSpareParts.Visible = false;
            pnlDashboard.Visible = false;
            pnlManageOrders.Visible = false;
            pnlGenReports.Visible = false;
            pnlAdminStaff.Visible = false;
            UpdateButtonColors(btnMngCustomers);
        }
        private void btn_mng_orders_Click(object sender, EventArgs e)
        {
            pnlManageOrders.Visible = true;
            pnlCustomerManagement.Visible = false;
            pnlMngCars.Visible = false;
            pnlSpareParts.Visible = false;
            pnlDashboard.Visible = false;
            pnlGenReports.Visible = false;
            pnlAdminStaff.Visible = false;
            UpdateButtonColors(btnMngOrders);
        }
        private void btn_mng_reports_Click(object sender, EventArgs e)
        {
            pnlGenReports.Visible = true;
            pnlManageOrders.Visible = false;
            pnlCustomerManagement.Visible = false;
            pnlMngCars.Visible = false;
            pnlSpareParts.Visible = false;
            pnlDashboard.Visible = false;
            //pnlGenReports.Visible = false;
            UpdateButtonColors(btnMngReports);
        }
        private void btn_admin_staff_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(btnAdminStaff);
            pnlAdminStaff.Visible = true;
            pnlGenReports.Visible = false;
            pnlManageOrders.Visible = false;
            pnlCustomerManagement.Visible = false;
            pnlMngCars.Visible = false;
            pnlSpareParts.Visible = false;
            pnlDashboard.Visible = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            login_form login_Form = new login_form();
            login_Form.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            login_form login_Form = new login_form();
            login_Form.Show();
            this.Hide();
        }
        private void UpdateButtonColors(Button selectedButton)
        {
            btnDashboard.BackColor = System.Drawing.Color.LightGray;
            btnMngCars.BackColor = System.Drawing.Color.Gainsboro;
            btnMngSparts.BackColor = System.Drawing.Color.Gainsboro;
            btnMngCustomers.BackColor = System.Drawing.Color.Gainsboro;
            btnMngOrders.BackColor = System.Drawing.Color.Gainsboro;
            btnMngReports.BackColor = System.Drawing.Color.Gainsboro;
            btnAdminStaff.BackColor = System.Drawing.Color.LightGray;

            selectedButton.BackColor = System.Drawing.Color.Silver;
        }


        //------------------------------- Combobox Handling -------------------------------
        //---------------------------------------------------------------------------------
        private void InitializeComboBox(ComboBox comboBox, List<string> items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());
        }

        private void comboBox_SelectedIndexChanged(object sender, Guna2ComboBox comboBox, Guna2TextBox textBox, EventArgs e)
        {
            if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() != " ")
            {
                textBox.Text = comboBox.SelectedItem.ToString();
            }
            else
            {
                textBox.Text = "";
            }
        }

        private void cmbCarMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_SelectedIndexChanged(sender, cmbCarMake, txtCarMake, e);
        }

        private void cmbCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_SelectedIndexChanged(sender, cmbCarModel, txtCarModel, e);
        }

        private void cmbSprPartCarMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_SelectedIndexChanged(sender, cmbSprPartCarMake, txtSprPartCarMake, e);
        }

        private void cmbSprPartCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_SelectedIndexChanged(sender, cmbSprPartCarModel, txtSprPartCarModel, e);
        }

        private void RefreshCarMakeComboBox()
        {
            List<string> carMakes = _context.CarMakes.Select(cm => cm.Make).Distinct().ToList();
            InitializeComboBox(cmbCarMake, carMakes);
        }

        private void RefreshCarModelComboBox()
        {
            List<string> carModels = _context.CarModels.Select(cm => cm.ModelName).Distinct().ToList();
            InitializeComboBox(cmbCarModel, carModels);
        }

        private void RefreshSparePartCarMakeComboBox()
        {
            List<string> spCarMakes = _context.CarMakes.Select(cm => cm.Make).Distinct().ToList();
            InitializeComboBox(cmbSprPartCarMake, spCarMakes);
        }

        private void RefreshSparePartCarModelComboBox()
        {
            List<string> spCarModels = _context.CarModels.Select(cm => cm.ModelName).Distinct().ToList();
            InitializeComboBox(cmbSprPartCarModel, spCarModels);
        }



        //------------------------------- Car Management -------------------------------
        //------------------------------------------------------------------------------

        // Save Car Info
        private void btnSaveCarInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string make = txtCarMake.Text;
                string model = txtCarModel.Text;

                if (!int.TryParse(txtCarYear.Text, out int year))
                {
                    MessageBox.Show("Please enter a valid year as an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string color = txtCarColor.Text;
                string fuelType = cmbCarFuelTyp.SelectedItem?.ToString() ?? string.Empty;
                string transmission = cmbCarTransmission.SelectedItem?.ToString() ?? string.Empty;
                string engineCapacity = txtCarEnCpcty.Text;
                string bodyType = cmbCarBodyTyp.SelectedItem?.ToString() ?? string.Empty;
                if (!int.TryParse(txtCarPrice.Text, out int price))
                {
                    MessageBox.Show("Please enter a valid price as an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string engineNo = txtEngNo.Text;
                string chassisNo = TxtChasNo.Text;
                string imagePath = picCarImg.Tag != null ? picCarImg.Tag.ToString() : string.Empty;
                string additionalFeatures = txtCarAddiFeatures.Text;
                DateTime createdAt = DateTime.Now;

                if (string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model) || year == 0 || string.IsNullOrEmpty(color) || string.IsNullOrEmpty(fuelType) || string.IsNullOrEmpty(transmission) || string.IsNullOrEmpty(engineCapacity) || string.IsNullOrEmpty(bodyType) || price == 0 || string.IsNullOrEmpty(engineNo) || string.IsNullOrEmpty(chassisNo) || string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var carModel = _context.CarModels.FirstOrDefault(cm => cm.ModelName == model);
                if (carModel == null)
                {
                    carModel = new CarModel { Id = GenerateId(), ModelName = model };
                    _context.CarModels.Add(carModel);
                }
                var carMake = _context.CarMakes.FirstOrDefault(cm => cm.Make == make && cm.CarModelId == carModel.Id);
                if (carMake == null)
                {
                    carMake = new CarMake { Id = GenerateId(), Make = make, CarModelId = carModel.Id, CarModel = carModel };
                    _context.CarMakes.Add(carMake);
                }

                // Create a new Car object
                Car newCar = new Car
                {
                    Id = Guid.NewGuid(),
                    CarMakeId = carMake.Id,
                    Year = year,
                    Color = color,
                    FuelType = fuelType,
                    Transmission = transmission,
                    EngineCapacity = engineCapacity,
                    BodyType = bodyType,
                    Price = price,
                    EngineNo = engineNo,
                    ChassisNo = chassisNo,
                    Image = imagePath,
                    AdditionalFeatures = additionalFeatures,
                    CreatedDate = createdAt,
                    UpdateDate = null,
                    DeletedDate = null
                };

                // Save to database
                _context.Cars.Add(newCar);
                _context.SaveChanges();

                MessageBox.Show("Car added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh ComboBoxes
                RefreshCarMakeComboBox();
                RefreshCarModelComboBox();

                ClearFields();

                DisplayCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving car details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GenerateId()
        {
            return _context.CarMakes.Max(cm => (int?)cm.Id) + 1 ?? 1;
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            string carImagePath = SelectAndSaveImage(ofdCarImage, "Car Images", picCarImg);
            if (string.IsNullOrEmpty(carImagePath))
            {
                MessageBox.Show("Car image was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void DisplayCars(string make = "", string model = "", int year = 0, string engNo = "", string chasNo = "")
        {
            pnlDisplayCars.Controls.Clear();

            // Define sizes and spaces
            Size panelSize = new Size(360, 140);
            int space = 5;

            // Fetch and filter cars
            var carsQuery = _context.Cars.Where(c => c.DeletedDate == null);

            if (!string.IsNullOrEmpty(make))
            {
                var carMakeIds = _context.CarMakes.Where(cm => cm.Make.Contains(make)).Select(cm => cm.Id).ToList();
                carsQuery = carsQuery.Where(c => carMakeIds.Contains(c.CarMakeId));
            }

            if (!string.IsNullOrEmpty(model))
            {
                var carModelIds = _context.CarModels.Where(cm => cm.ModelName.Contains(model)).Select(cm => cm.Id).ToList();
                var carMakeIds = _context.CarMakes.Where(cm => carModelIds.Contains(cm.CarModelId)).Select(cm => cm.Id).ToList();
                carsQuery = carsQuery.Where(c => carMakeIds.Contains(c.CarMakeId));
            }

            if (year > 0)
            {
                carsQuery = carsQuery.Where(c => c.Year == year);
            }

            if (!string.IsNullOrEmpty(engNo))
            {
                carsQuery = carsQuery.Where(c => c.EngineNo.Contains(engNo));
            }

            if (!string.IsNullOrEmpty(chasNo))
            {
                carsQuery = carsQuery.Where(c => c.ChassisNo.Contains(chasNo));
            }

            var cars = carsQuery.OrderByDescending(c => c.CreatedDate).ToList();

            int yPos = space; // Start position

            foreach (var car in cars)
            {
                var carMake = _context.CarMakes.FirstOrDefault(cm => cm.Id == car.CarMakeId);
                var carModel = carMake != null ? _context.CarModels.FirstOrDefault(m => m.Id == carMake.CarModelId) : null;

                // Create panel for car
                Panel carPanel = new Panel
                {
                    Size = panelSize,
                    Location = new Point(5, yPos),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.WhiteSmoke
                };

                if (!string.IsNullOrEmpty(car.Image) && File.Exists(car.Image))
                {
                    PictureBox picCar = new PictureBox
                    {
                        Image = Image.FromFile(car.Image),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(150, 100),
                        Location = new Point(10, 11) 
                    };
                    carPanel.Controls.Add(picCar);
                }

                // Add car details to the panel
                Label lblMakeModel = new Label
                {
                    Text = $"Model: {carMake?.Make} {carModel?.ModelName}",
                    Location = new Point(170, 10), 
                    AutoSize = true
                };
                carPanel.Controls.Add(lblMakeModel);

                Label lblYear = new Label
                {
                    Text = $"Year: {car.Year}",
                    Location = new Point(170, 30),
                    AutoSize = true
                };
                carPanel.Controls.Add(lblYear);

                Label lblColor = new Label
                {
                    Text = $"Engine No: {car.EngineNo}",
                    Location = new Point(170, 50),
                    AutoSize = true
                };
                carPanel.Controls.Add(lblColor);

                Label lblPrice = new Label
                {
                    Text = $"Chassis No: {car.ChassisNo}",
                    Location = new Point(170, 70),
                    AutoSize = true
                };
                carPanel.Controls.Add(lblPrice);

                Guna2Button btnViewDetails = new Guna2Button
                {
                    Text = "View Details",
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(98, 26),
                    Location = new Point(170, 88),
                    BorderRadius = 4,
                    Cursor = Cursors.Hand,
                    Tag = car.Id
                };
                btnViewDetails.Click += (s, e) => ViewCarDetails((Guid)((Guna2Button)s).Tag);
                carPanel.Controls.Add(btnViewDetails);

                pnlDisplayCars.Controls.Add(carPanel);

                yPos += panelSize.Height + space;
            }
        }


        private Guid selectedCarId;

        private void ViewCarDetails(Guid carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
            {
                MessageBox.Show("Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fill in the details
            txtCarMake.Text = car.CarMake?.Make;
            txtCarModel.Text = car.CarMake?.CarModel?.ModelName;
            txtCarYear.Text = car.Year.ToString();
            txtCarColor.Text = car.Color;
            cmbCarFuelTyp.SelectedItem = car.FuelType;
            cmbCarTransmission.SelectedItem = car.Transmission;
            txtCarEnCpcty.Text = car.EngineCapacity;
            cmbCarBodyTyp.SelectedItem = car.BodyType;
            txtCarPrice.Text = car.Price.ToString();
            txtEngNo.Text = car.EngineNo;
            TxtChasNo.Text = car.ChassisNo;
            if (string.IsNullOrEmpty(car.Image) || !File.Exists(car.Image))
            {
                picCarImg.Image = null;
            }
            else
            {
                picCarImg.Image = Image.FromFile(car.Image);
                picCarImg.SizeMode = PictureBoxSizeMode.Zoom;
            }
            picCarImg.Tag = car.Image;
            txtCarAddiFeatures.Text = car.AdditionalFeatures;

            btnUpdateCar.Visible = true;
            btnDeleteCar.Visible = true;

            // Store the selected car ID
            selectedCarId = carId;
        }

        private void btnSearchCarInfo_Click(object sender, EventArgs e)
        {
            var carMake = txtCarMake.Text.Trim();
            var carModel = txtCarModel.Text.Trim();
            var year = txtCarYear.Text.Trim();
            var engNo = txtEngNo.Text.Trim();
            var chasNo = TxtChasNo.Text.Trim();

            DisplayCars(carMake, carModel, int.TryParse(year, out int y) ? y : 0, engNo, chasNo);
        }

        private void UpdateCar(Guid carId)
        {
            try
            {
                // Find the car to update
                var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
                if (car == null)
                {
                    MessageBox.Show("Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the car details
                car.CarMake.Make = txtCarMake.Text;
                car.CarMake.CarModel.ModelName = txtCarModel.Text;
                if (!int.TryParse(txtCarYear.Text, out int year))
                {
                    MessageBox.Show("Please enter a valid year as an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                car.Year = year;
                car.Color = txtCarColor.Text;
                car.FuelType = cmbCarFuelTyp.SelectedItem?.ToString() ?? string.Empty;
                car.Transmission = cmbCarTransmission.SelectedItem?.ToString() ?? string.Empty;
                car.EngineCapacity = txtCarEnCpcty.Text;
                car.BodyType = cmbCarBodyTyp.SelectedItem?.ToString() ?? string.Empty;
                if (!int.TryParse(txtCarPrice.Text, out int price))
                {
                    MessageBox.Show("Please enter a valid price as an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                car.Price = price;
                car.EngineNo = txtEngNo.Text;
                car.ChassisNo = TxtChasNo.Text;
                car.AdditionalFeatures = txtCarAddiFeatures.Text;
                car.DeletedDate = null;

                if (!string.IsNullOrEmpty(picCarImg.Tag?.ToString()) && picCarImg.Tag.ToString() != car.Image)
                {
                    // Update image path if a new image was selected
                    car.Image = picCarImg.Tag.ToString();
                }

                _context.SaveChanges();

                MessageBox.Show("Car updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields and hide update button
                ClearFields();
                

                // Refresh the displayed cars
                DisplayCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating car details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            UpdateCar(selectedCarId);
            btnDeleteCar.Visible = false;
            btnUpdateCar.Visible = false;
        }

        private void DeleteCar(Guid carId)
        {
            try
            {
                // Find the car to delete
                var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
                if (car == null)
                {
                    MessageBox.Show("Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mark the car as deleted
                car.DeletedDate = DateTime.Now;
                _context.SaveChanges();

                MessageBox.Show("Car marked as deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields and hide delete button
                ClearFields();

                // Refresh the displayed cars
                DisplayCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking car as deleted: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            DeleteCar(selectedCarId);
            btnDeleteCar.Visible = false;
            btnUpdateCar.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            DisplayCars();
            btnUpdateCar.Visible = false;
            btnDeleteCar.Visible = false;
        }




        //------------------------------- Spare Parts Management -------------------------------
        //--------------------------------------------------------------------------------------

        // Save Spare Part Info
        private void btnSaveSprParts_Click(object sender, EventArgs e)
        {
            try
            {
                // Gather data from fields
                string partName = txtSprPartName.Text;
                string category = cmbSprPartCategory.SelectedItem?.ToString() ?? string.Empty;
                string carMake = txtSprPartCarMake.Text;
                string carModel = txtSprPartCarModel.Text;
                string manufacturer = txtSprPartManufacturer.Text;
                string description = txtSprPartDescription.Text;
                string warrantyPeriod = cmbSprPartWarrantyPeriod.SelectedItem?.ToString() ?? string.Empty;
                int stockQuantity = (int)nudSprPartQuantity.Value;
                if (!int.TryParse(txtSprPartPrice.Text, out int price))
                {
                    MessageBox.Show("Please enter a valid price as an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string imagePath = pictureBoxSpareParts.Tag != null ? pictureBoxSpareParts.Tag.ToString() : string.Empty;
                //string status = "Available";
                DateTime createdAt = DateTime.Now;
                

                if (
                    string.IsNullOrEmpty(partName) ||
                    string.IsNullOrEmpty(category) ||
                    string.IsNullOrEmpty(carMake) ||
                    string.IsNullOrEmpty(carModel) ||
                    string.IsNullOrEmpty(manufacturer) ||
                    string.IsNullOrEmpty(description) ||
                    string.IsNullOrEmpty(warrantyPeriod) ||
                    stockQuantity == 0 ||
                    price == 0 ||
                    string.IsNullOrEmpty(imagePath)
                )
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure CarMake and CarModel exist
                var modelEntity = _context.CarModels.FirstOrDefault(cm => cm.ModelName == carModel);
                if (modelEntity == null)
                {
                    modelEntity = new CarModel { Id = GenerateId(), ModelName = carModel };
                    _context.CarModels.Add(modelEntity);
                    _context.SaveChanges();
                }

                var makeEntity = _context.CarMakes.FirstOrDefault(cm => cm.Make == carMake && cm.CarModelId == modelEntity.Id);
                if (makeEntity == null)
                {
                    makeEntity = new CarMake { Id = GenerateId(), Make = carMake, CarModelId = modelEntity.Id, CarModel = modelEntity };
                    _context.CarMakes.Add(makeEntity);
                    _context.SaveChanges();
                }

                CarSparePart newSparePart = new CarSparePart
                {
                    Id = Guid.NewGuid(),
                    PartName = partName,
                    Category = category,
                    CarMakeId = _context.CarMakes.FirstOrDefault(cm => cm.Make == carMake)?.Id ?? 0,
                    Description = description,
                    Manufacturer = manufacturer,
                    Price = price,
                    StockQuantity = stockQuantity,
                    WarrantyPeriod = warrantyPeriod,
                    ImagePath = imagePath,
                    DateAdded = createdAt,
                    DateDeletedAt = null
                };

                _context.CarSpareParts.Add(newSparePart);
                _context.SaveChanges();

                MessageBox.Show("Spare part added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshSparePartCarMakeComboBox();
                RefreshSparePartCarModelComboBox(); 

                // Clear fields
                ClearFields();

                DisplaySpareParts();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"Database update error: {dbEx.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving spare part details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSprPartAddImage_Click(object sender, EventArgs e)
        {
            string sparePartImagePath = SelectAndSaveImage(ofdSprPartImage, "Spare Parts Images", pictureBoxSpareParts);
            if (string.IsNullOrEmpty(sparePartImagePath))
            {
                MessageBox.Show("Spare part image was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySpareParts(string category = "", string partName = "", string carMake = "", string carModel = "")
        {
            pnlDisplaySprParts.Controls.Clear();

            // Define sizes and spaces
            Size panelSize = new Size(430, 130);
            int space = 5;

            // Fetch and filter spare parts
            var sparePartsQuery = _context.CarSpareParts.Where(sp => sp.DateDeletedAt == null);


            if (!string.IsNullOrEmpty(category) && category != " ")
            {
                sparePartsQuery = sparePartsQuery.Where(sp => sp.Category == category);
            }

            if (!string.IsNullOrEmpty(partName))
            {
                sparePartsQuery = sparePartsQuery.Where(sp => sp.PartName.Contains(partName));
            }

            if (!string.IsNullOrEmpty(carMake) && carMake != " ")
            {
                var carMakeIds = _context.CarMakes.Where(cm => cm.Make == carMake).Select(cm => cm.Id).ToList();
                sparePartsQuery = sparePartsQuery.Where(sp => carMakeIds.Contains(sp.CarMakeId));
            }

            if (!string.IsNullOrEmpty(carModel) && carModel != " ")
            {
                var carModelIds = _context.CarModels.Where(cm => cm.ModelName == carModel).Select(cm => cm.Id).ToList();
                var carMakeIds = _context.CarMakes.Where(cm => carModelIds.Contains(cm.CarModelId)).Select(cm => cm.Id).ToList();
                sparePartsQuery = sparePartsQuery.Where(sp => carMakeIds.Contains(sp.CarMakeId));
            }

            var spareParts = sparePartsQuery.OrderByDescending(sp => sp.DateAdded).ToList();

            int yPos = space; // Start position

            foreach (CarSparePart sparePart in spareParts)
            {
                // Create panel for spare part
                Panel sparePartPanel = new Panel
                {
                    Size = panelSize,
                    Location = new Point(5, yPos),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.WhiteSmoke
                };

                if (!string.IsNullOrEmpty(sparePart.ImagePath) && File.Exists(sparePart.ImagePath))
                {
                    PictureBox picSparePart = new PictureBox
                    {
                        Image = Image.FromFile(sparePart.ImagePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(150, 100),
                        Location = new Point(10, 11) // Position the PictureBox at the top left
                    };
                    sparePartPanel.Controls.Add(picSparePart);
                }

                // Add spare part details to the panel
                Label lblPartName = new Label
                {
                    Text = $"Part Name: {sparePart.PartName}",
                    Location = new Point(170, 10), // Position details to the right of PictureBox
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblPartName);

                // Fetch the CarMake and CarModel explicitly
                var carMakeEntity = _context.CarMakes.FirstOrDefault(cm => cm.Id == sparePart.CarMakeId);
                var carModelEntity = carMakeEntity != null ? _context.CarModels.FirstOrDefault(m => m.Id == carMakeEntity.CarModelId) : null;
                string carMakeAndModel = (carMakeEntity != null ? carMakeEntity.Make : "Unknown Make") + " " + (carModelEntity != null ? carModelEntity.ModelName : "Unknown Model");

                Label lblCarMake = new Label
                {
                    Text = $"Car Model: {carMakeAndModel}",
                    Location = new Point(170, 35), 
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblCarMake);

                Label lblStockQuantity = new Label
                {
                    Text = $"Stock Quantity: {sparePart.StockQuantity}",
                    Location = new Point(170, 60),
                    AutoSize = true
                };
                sparePartPanel.Controls.Add(lblStockQuantity);

                Guna2Button btnViewDetails = new Guna2Button
                {
                    Text = "View Details",
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(100, 28),
                    Location = new Point(170, 82),
                    BorderRadius = 4,
                    Cursor = Cursors.Hand,
                    Tag = sparePart.Id
                };
                btnViewDetails.Click += (s, e) => ViewSparePartDetails((Guid)((Guna2Button)s).Tag);
                sparePartPanel.Controls.Add(btnViewDetails);

                pnlDisplaySprParts.Controls.Add(sparePartPanel);

                yPos += panelSize.Height + space; // Update position for the next panel
            }
        }

        private Guid selectedSparePartId;

        private void ViewSparePartDetails(Guid sparePartId)
        {
            var sparePart = _context.CarSpareParts.FirstOrDefault(sp => sp.Id == sparePartId);
            if (sparePart == null)
            {
                MessageBox.Show("Spare part not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fill in the details
            txtSprPartName.Text = sparePart.PartName;
            cmbSprPartCategory.SelectedItem = sparePart.Category;

            var carMake = _context.CarMakes.FirstOrDefault(cm => cm.Id == sparePart.CarMakeId);
            if (carMake != null)
            {
                cmbSprPartCarMake.SelectedItem = carMake.Make;
                var carModel = _context.CarModels.FirstOrDefault(m => m.Id == carMake.CarModelId);
                if (carModel != null)
                {
                    cmbSprPartCarModel.SelectedItem = carModel.ModelName;
                }
                else
                {
                    cmbSprPartCarModel.SelectedIndex = 0; // Default selection
                }
            }
            else
            {
                cmbSprPartCarMake.SelectedIndex = 0; // Default selection
                cmbSprPartCarModel.SelectedIndex = 0; // Default selection
            }

            txtSprPartManufacturer.Text = sparePart.Manufacturer;
            txtSprPartDescription.Text = sparePart.Description;
            cmbSprPartWarrantyPeriod.SelectedItem = sparePart.WarrantyPeriod;
            nudSprPartQuantity.Value = sparePart.StockQuantity;
            txtSprPartPrice.Text = sparePart.Price.ToString();
            if (string.IsNullOrEmpty(sparePart.ImagePath) || !File.Exists(sparePart.ImagePath))
            {
                pictureBoxSpareParts.Image = null;
            }
            else
            {
                pictureBoxSpareParts.Image = Image.FromFile(sparePart.ImagePath);
                pictureBoxSpareParts.SizeMode = PictureBoxSizeMode.Zoom;
            }
            pictureBoxSpareParts.Tag = sparePart.ImagePath;

            btnSprPartUpdate.Visible = true;
            btnSprPartDelete.Visible = true;

            // Store the selected spare part ID
            selectedSparePartId = sparePartId;
        }


        // Search Spare Parts
        private void btnSearchSprParts_Click(object sender, EventArgs e)
        {
            // Capture search criteria
            string category = cmbSprPartCategory.SelectedItem?.ToString() ?? string.Empty;
            string partName = txtSprPartName.Text.Trim();
            string carMake = cmbSprPartCarMake.SelectedItem?.ToString() ?? string.Empty;
            string carModel = cmbSprPartCarModel.SelectedItem?.ToString() ?? string.Empty;

            // Display filtered spare parts
            DisplaySpareParts(category, partName, carMake, carModel);
        }

        private void btnClearSprParts_Click(object sender, EventArgs e)
        {
            ClearFields();
            btnSprPartUpdate.Visible = false;
            btnSprPartDelete.Visible = false;
        }


        private void UpdateSparePart(Guid sparePartId)
        {
            try
            {
                // Find the spare part to update
                var sparePart = _context.CarSpareParts.FirstOrDefault(sp => sp.Id == sparePartId);
                if (sparePart == null)
                {
                    MessageBox.Show("Spare part not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the spare part details
                sparePart.PartName = txtSprPartName.Text;
                sparePart.Category = cmbSprPartCategory.SelectedItem?.ToString() ?? string.Empty;

                var selectedCarMake = cmbSprPartCarMake.SelectedItem?.ToString();
                if (selectedCarMake != null)
                {
                    var carMake = _context.CarMakes.FirstOrDefault(cm => cm.Make == selectedCarMake);
                    if (carMake != null)
                    {
                        sparePart.CarMakeId = carMake.Id;
                    }
                }

                sparePart.Description = txtSprPartDescription.Text;
                sparePart.Manufacturer = txtSprPartManufacturer.Text;
                sparePart.WarrantyPeriod = cmbSprPartWarrantyPeriod.SelectedItem?.ToString() ?? string.Empty;
                sparePart.StockQuantity = (int)nudSprPartQuantity.Value;

                if (!int.TryParse(txtSprPartPrice.Text, out int price))
                {
                    MessageBox.Show("Please enter a valid price as an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sparePart.Price = price;
                sparePart.DateDeletedAt = null;

                if (!string.IsNullOrEmpty(pictureBoxSpareParts.Tag?.ToString()) && pictureBoxSpareParts.Tag.ToString() != sparePart.ImagePath)
                {
                    // Update image path if a new image was selected
                    sparePart.ImagePath = pictureBoxSpareParts.Tag.ToString();
                }

                _context.SaveChanges();

                MessageBox.Show("Spare part updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields and hide update button

                ClearFields();

                // Refresh the displayed spare parts
                DisplaySpareParts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating spare part details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteSparePart(Guid sparePartId)
        {
            try
            {
                // Find the spare part to delete
                var sparePart = _context.CarSpareParts.FirstOrDefault(sp => sp.Id == sparePartId);
                if (sparePart == null)
                {
                    MessageBox.Show("Spare part not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mark the spare part as deleted
                sparePart.DateDeletedAt = DateTime.Now;
                _context.SaveChanges();

                MessageBox.Show("Spare part marked as deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields and hide delete button
                ClearFields();

                // Refresh the displayed spare parts
                DisplaySpareParts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking spare part as deleted: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSprPartUpdate_Click(object sender, EventArgs e)
        {
            UpdateSparePart(selectedSparePartId);

            btnSprPartUpdate.Visible = false;
            btnSprPartDelete.Visible = false;
        }

        private void btnSprPartDelete_Click(object sender, EventArgs e)
        {
            DeleteSparePart(selectedSparePartId);

            btnSprPartUpdate.Visible = false;
            btnSprPartDelete.Visible = false;
        }

        private string SelectAndSaveImage(OpenFileDialog openFileDialog, string folderName, PictureBox pictureBox)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    pictureBox.Image = Image.FromFile(filePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string fileName = $"{Guid.NewGuid()}.jpg";
                    string savePath = Path.Combine(directory, fileName);

                    pictureBox.Image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    pictureBox.Tag = savePath;
                    return savePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            return string.Empty;
        }




        //------------------------------- Customer Management -------------------------------
        //-----------------------------------------------------------------------------------

        // ViewModel to shape data for display in the DataGridView
        public class UserDisplayModel
        {
            public Guid UserId { get; set; }  
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Status { get; set; }
        }

        private List<UserDisplayModel> FetchUserData()
        {
            return _context.Users
                .Select(user => new UserDisplayModel
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Status = user.IsActive ? "Active" : "Inactive"
                })
                .ToList();
        }

        private void DisplayUsers()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.Columns.Clear();

            var users = FetchUserData();
            dgvCustomers.DataSource = users;

            // Hide the UserId column
            dgvCustomers.Columns["UserId"].Visible = false;
        }

        // Search Customer
        public void SearchCustomerByEmailOrPnone()
        {
            var cusEmail = txtSearchCustomer.Text.Trim().ToLowerInvariant();
            var cusPhone = txtSearchCustomer.Text.Trim().ToLowerInvariant();

            if (string.IsNullOrEmpty(cusEmail))
            {
                MessageBox.Show("Please enter a valid email address or phone number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var users = _context.Users
                    .AsEnumerable()  
                    .Where(user => string.Equals(user.Email.Trim(), cusEmail, StringComparison.OrdinalIgnoreCase) || string.Equals(user.Phone.Trim(), cusPhone, StringComparison.OrdinalIgnoreCase))
                    .Select(user => new UserDisplayModel
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Phone = user.Phone,
                        Status = user.IsActive ? "Active" : "Inactive"
                    })
                    .ToList();

                var matchingCustomer = users.FirstOrDefault();

                if (matchingCustomer != null)
                {
                    var allUsers = FetchUserData();

                    allUsers.RemoveAll(u => string.Equals(u.Email.Trim(), matchingCustomer.Email.Trim(), StringComparison.OrdinalIgnoreCase));

                    allUsers.Insert(0, matchingCustomer);

                    dgvCustomers.DataSource = null;
                    dgvCustomers.Columns.Clear();
                    dgvCustomers.DataSource = allUsers;
                    dgvCustomers.Columns["UserId"].Visible = false;

                }
                else
                {
                    MessageBox.Show("No customer found with the provided information.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txtSearchCustomer.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picSearchCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomerByEmailOrPnone();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                var selectedUser = dgvCustomers.Rows[rowIndex].DataBoundItem as UserDisplayModel;
                if (selectedUser != null)
                {
                    txtCusName.Text = selectedUser.Name;
                    txtCusEmail.Text = selectedUser.Email;
                    txtCusPhone.Text = selectedUser.Phone;

                    var deletedUser = _context.Users
                        .FirstOrDefault(u => u.Email == selectedUser.Email && u.DeletedDate != null);

                    if (deletedUser != null)
                    {
                        lblDeletedAccount.Text = "Deleted Account";
                        pnlCustomerDetails.BackColor = Color.WhiteSmoke;
                        lblCusName.BackColor = Color.WhiteSmoke;
                        lblCusEmail.BackColor = Color.WhiteSmoke;
                        lblCusPhone.BackColor = Color.WhiteSmoke;
                        lblCustomerDetails.BackColor = Color.WhiteSmoke;
                        btnDeleteCus.Enabled = false;
                        btnEditCusDetails.Enabled = false;
                    }
                    else
                    {
                        lblDeletedAccount.Text = string.Empty;
                        pnlCustomerDetails.BackColor = Color.White;
                        lblCusName.BackColor = Color.White;
                        lblCusEmail.BackColor = Color.White;
                        lblCusPhone.BackColor = Color.White;
                        lblCustomerDetails.BackColor = Color.White;
                        btnDeleteCus.Enabled = true;
                        btnEditCusDetails.Enabled = true;
                    }

                    // Retrieve orders for the selected customer
                    var orders = _context.Orders
                        .Where(o => o.UserId == selectedUser.UserId && o.DeletedDate == null)
                        .Select(o => new OrderDisplayModel
                        {
                            OrderId = o.Id,
                            OrderType = o.CarId != null ? "Car Order" : (o.SparePartId != null ? "Spare Part Order" : "Unknown"),
                            ItemName = o.CarId != null ? o.Car.CarMake.Make + " " + o.Car.CarMake.CarModel.ModelName: (o.SparePartId != null ? o.CarSparePart.PartName : "Unknown"),
                            ImagePath = o.CarId != null ? o.Car.Image : (o.SparePartId != null ? o.CarSparePart.ImagePath : string.Empty),
                            OrderedDate = o.CreatedDate,
                            Price = o.CarId != null ? o.Car.Price : (o.SparePartId != null ? o.CarSparePart.Price : 0),
                        })
                        .OrderByDescending(o => o.OrderedDate)
                        .ToList();

                    pnlViewSelectedCustomerOrders.Controls.Clear();

                    if (!orders.Any())
                    {
                        Label label = new Label
                        {
                            Text = "No orders found for the selected customer.",
                            AutoSize = true,
                            Location = new Point(5, 5)
                        };
                        pnlViewSelectedCustomerOrders.Controls.Add(label);
                    }
                    else
                    {
                        DisplaySelectedCustomerOrders(orders);
                    }
                }
            }

        }


        public void DisplaySelectedCustomerOrders(IEnumerable<OrderDisplayModel> selectedUserOrders)
        {
            pnlViewSelectedCustomerOrders.Controls.Clear();

            Size panelSize = new Size(448, 125);
            int space = 8;

            int yPos = space; 

            foreach (var order in selectedUserOrders)
            {
                Panel orderPanel = new Panel
                {
                    Size = panelSize,
                    Location = new Point(5, yPos),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.WhiteSmoke
                };

                PictureBox pictureBox = new PictureBox
                {   
                    Image = Image.FromFile(order.ImagePath),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(150, 100),
                    Location = new Point(10, 10) 
                };
                orderPanel.Controls.Add(pictureBox);

                Label lblOrderType = new Label
                {
                    Text = $"Order Type: {order.OrderType}",
                    Location = new Point(180, 10), 
                    AutoSize = true
                };
                orderPanel.Controls.Add(lblOrderType);

                Label lblItemName = new Label
                {
                    Text = $"Item Name: {order.ItemName}",
                    Location = new Point(180, 32), 
                    AutoSize = true
                };
                orderPanel.Controls.Add(lblItemName);

                Label lblPurchaseDate = new Label
                {
                    Text = $"Purchase Date: {order.OrderedDate}",
                    Location = new Point(180, 54),
                    AutoSize = true
                };
                orderPanel.Controls.Add(lblPurchaseDate);

                Label lblPrice = new Label
                {
                    Text = $"Price: {order.Price}",
                    Location = new Point(180, 76),
                    AutoSize = true
                };
                orderPanel.Controls.Add(lblPrice);

                Label lblStatus = new Label
                {
                    Text = $"Status: {order.Status}",
                    Location = new Point(180, 98),
                    AutoSize = true
                };
                orderPanel.Controls.Add(lblStatus);

                pnlViewSelectedCustomerOrders.Controls.Add(orderPanel);

                yPos += panelSize.Height + space; 
            }
        }

        private void btnDeleteCus_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = _context.Users.Where(u => u.Email == txtCusEmail.Text).FirstOrDefault();
                if (customer != null)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    customer.DeletedDate = DateTime.Now;
                    _context.SaveChanges();
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error deleting customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCusDetails_Click(object sender, EventArgs e)
        {
            txtCusName.Enabled = true;
            txtCusEmail.Enabled = true;
            txtCusPhone.Enabled = true;

            btnSaveEdditedCus.Visible = true;
        }

        private void btnSaveEdditedCus_Click(object sender, EventArgs e)
        {
            try
            {
                var cusEmail = txtCusEmail.Text.Trim().ToLowerInvariant();

                var customer = _context.Users
                    .FirstOrDefault(user => user.Email.ToLower() == cusEmail);

                if (customer != null)
                {
                    customer.Name = txtCusName.Text.Trim();
                    customer.Phone = txtCusPhone.Text.Trim();

                    _context.SaveChanges();

                    DisplayUsers();

                    MessageBox.Show("Customer details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCusName.Enabled = false;
                    txtCusEmail.Enabled = false;
                    txtCusPhone.Enabled = false;
                    btnSaveEdditedCus.Visible = false;

                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //--------------------------------------- Order Management --------------------------------
        //-----------------------------------------------------------------------------------------
        public class OrderDisplayModel
        {
            public Guid OrderId { get; set; }
            public string OrderType { get; set; }
            public string ItemName { get; set; }
            public string ImagePath { get; set; }
            public int Quantity { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerPhone { get; set; }
            public DateTime OrderedDate { get; set; }
            public DateTime CancelDate { get; set; }
            public decimal Price { get; set; }
            public string Status { get; set; }
            public string Option { get; set; }
        }

        private List<OrderDisplayModel> GetAllOrders()
        {
            var orders = _context.Orders.Where(o => o.Option == null && o.DeletedDate == null)
                .Select(o => new OrderDisplayModel
                {
                    OrderId = o.Id,
                    OrderType = o.Car != null ? "Car Order" : (o.CarSparePart != null ? "Spare Part Order" : "Unknown"),
                    ItemName = o.Car != null ? o.Car.CarMake.Make + " " + o.Car.CarMake.CarModel.ModelName : (o.CarSparePart != null ? o.CarSparePart.PartName : "Unknown"),
                    ImagePath = o.Car != null ? o.Car.Image : (o.CarSparePart != null ? o.CarSparePart.ImagePath : string.Empty),
                    Quantity = o.Quantity.Value,
                    CustomerName = o.User.Name,
                    CustomerAddress = o.User.Address,
                    CustomerPhone = o.User.Phone,
                    OrderedDate = o.CreatedDate,
                    Price = o.Car != null ? o.Car.Price : (o.CarSparePart != null ? o.CarSparePart.Price : 0),
                    Status = o.DeletedDate != null ? "Deleted" : "Active"
                })
                .OrderByDescending(o => o.OrderedDate)
                .ToList();

            return orders;

        }

        private Queue<OrderDisplayModel> _ordersQueue = new Queue<OrderDisplayModel>();

        private void OrdersQueue()
        {
            var allOrdersDescending = GetAllOrders();

            _ordersQueue.Clear();
            foreach (var order in allOrdersDescending)
            {
                _ordersQueue.Enqueue(order);
            }

            DisplayOrdersQueue();
        }

        public void DisplayOrdersQueue()
        {
            pnlTableOrderRows.Controls.Clear();

            int i = 0;
            while (_ordersQueue.Count > 0)
            {
                var order = _ordersQueue.Dequeue();
                AddOrderToTableLayoutPanel(order, i);
                i++;
            }
        }
        private Label CreateLabel(string text, int width, int height, int xLocation, int yLocation)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(9, 0, 0, 0),
                Size = new Size(width, height),
                Location = new Point(xLocation, yLocation)
            };
        }

        private Guna2Button CreateButton(string text, int rowIndex, EventHandler onClickHandler)
        {
            Guna2Button button = new Guna2Button
            {
                Text = text,
                Size = new Size(80, 30),
                BorderRadius = 4,
                BorderThickness = 0,
                BorderColor = Color.FromArgb(0, 114, 198),
                Cursor = Cursors.Hand,
                Tag = rowIndex,
                Anchor = AnchorStyles.None
            };

            button.Click += onClickHandler;

            return button;
        }

        private void SetupTableLayoutPanelHeaders()
        {
            string[] headers = new string[]
            {
                "Category", "Item", "Name", "Ordered At", "Actions"
            };

            pnlTableOrdersHeaders.Controls.Clear();

            int columnsForData = headers.Length - 1;
            int columnWidth = pnlTableOrderRows.Width / (columnsForData + 2);
            int actionsWidth = pnlTableOrderRows.Width - (columnWidth * columnsForData);
            int labelHeight = 30;
            int yLocation = 7;

            for (int i = 0; i < headers.Length; i++)
            {
                int width = (i == headers.Length - 1) ? actionsWidth : columnWidth;
                Label headerLabel = CreateLabel(headers[i], width, labelHeight, i * columnWidth, yLocation);
                headerLabel.ForeColor = Color.White;
                pnlTableOrdersHeaders.Controls.Add(headerLabel);
            }
        }

        private List<List<Control>> _rowControls = new List<List<Control>>();

        private void AddRowToTableWithSeparator(string[] rowData, int rowIndex)
        {
            int columnsForData = rowData.Length;
            int columnWidth = pnlTableOrderRows.Width / (columnsForData + 2);
            int actionsWidth = pnlTableOrderRows.Width - (columnWidth * columnsForData);
            int labelHeight = 50;
            int yLocation = rowIndex * (labelHeight + 5);

            List<Control> rowControls = new List<Control>();

            // Add labels to the row
            for (int i = 0; i < rowData.Length; i++)
            {
                int width = columnWidth;
                Label rowLabel = CreateLabel(rowData[i], width, labelHeight, i * columnWidth, yLocation);
                rowLabel.ForeColor = Color.Black;
                rowLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                pnlTableOrderRows.Controls.Add(rowLabel);
                rowControls.Add(rowLabel);
            }

            int buttonXStart = rowData.Length * columnWidth;

            // Add the "Check" button
            Guna2Button checkButton = CreateButton("Check", rowIndex, (s, e) => CheckOn((int)((Guna2Button)s).Tag));
            checkButton.Location = new Point(buttonXStart, yLocation + (labelHeight - checkButton.Height) / 2);
            pnlTableOrderRows.Controls.Add(checkButton);
            rowControls.Add(checkButton);

            // Add the "Reject" button
            Guna2Button rejectButton = CreateButton("Reject", rowIndex, (s, e) => PassOrderIdToRejectOrderForm((int)((Guna2Button)s).Tag));
            rejectButton.Location = new Point(buttonXStart + checkButton.Width + 15, yLocation + (labelHeight - rejectButton.Height) / 2);
            rejectButton.FillColor = Color.Firebrick;
            pnlTableOrderRows.Controls.Add(rejectButton);
            rowControls.Add(rejectButton);

            // Add the "Accept" button
            Guna2Button acceptButton = CreateButton("Accept", rowIndex, (s, e) => AcceptOrder((int)((Guna2Button)s).Tag));
            acceptButton.Location = new Point(buttonXStart + checkButton.Width + rejectButton.Width + 30, yLocation + (labelHeight - acceptButton.Height) / 2);
            acceptButton.FillColor = Color.Green;
            pnlTableOrderRows.Controls.Add(acceptButton);
            rowControls.Add(acceptButton);

            // Add a separator line
            Guna2Separator separator = new Guna2Separator
            {
                Size = new Size(pnlTableOrderRows.Width, 2),
                Location = new Point(0, yLocation + labelHeight),
                FillColor = Color.Gray
            };

            pnlTableOrderRows.Controls.Add(separator);
            rowControls.Add(separator);

            _rowControls.Add(rowControls);
        }

        private void AddOrderToTableLayoutPanel(OrderDisplayModel order, int rowIndex)
        {
            string[] rowData = new string[]
            {
                order.OrderType,
                order.ItemName,
                order.CustomerName,
                order.OrderedDate.ToString("yyyy-MM-dd"),
            };

            AddRowToTableWithSeparator(rowData, rowIndex);
        }

        public OrderDisplayModel GetOrderFromRowIndex(int rowIndex)
        {
            var allOrdersDescending = GetAllOrders();
            return allOrdersDescending.ElementAtOrDefault(rowIndex);
        }



        private void RefreshOrdersDisplay()
        {
            OrdersQueue();
        }

        private void SetupTableWithRowsAndSeparators()
        {
            pnlTableOrderRows.Controls.Clear();
            SetupTableLayoutPanelHeaders();
            OrdersQueue();
        }


        private void CheckOn(int rowIndex)
        {
            var order = GetOrderFromRowIndex(rowIndex);
            if (order != null)
            {
                lblOrdertype.Text = order.OrderType;
                lblItemName.Text = $"Item Name :  {order.ItemName}";
                lblCustomerName.Text = $"Customer Name :  {order.CustomerName}";
                lblCustomerPhone.Text = $"Customer Phone :  {order.CustomerPhone}";
                lblCustomerAddress.Text = $"Customer Address :  {order.CustomerAddress}";
                lblQuantity.Text = $"Required Quantity :  {order.Quantity}";

                try
                {
                    string imagePath = order.ImagePath;

                    if (imagePath != null)
                    {
                        pbItem.Image = Image.FromFile(imagePath);
                        pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Image not found or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid row index.");
            }
        }



        private void PassOrderIdToRejectOrderForm(int rowIndex)
        {
            var order = GetOrderFromRowIndex(rowIndex);
            if (order != null)
            {
                RejectOrder rejectOrderForm = new RejectOrder(order.OrderId, order.OrderType, this, rowIndex);
                if (rejectOrderForm.ShowDialog() == DialogResult.OK)
                {
                    RemoveOrderRow(rowIndex);
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Invalid row index.");
            }
        }
        private void btnRejectOrder_Click(object sender, EventArgs e)
        {
            Guna2Button rejectButton = sender as Guna2Button;

            if (rejectButton != null && rejectButton.Tag is int rowIndex)
            {
                PassOrderIdToRejectOrderForm(rowIndex);
            }
            else
            {
                MessageBox.Show("Failed to identify the selected order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveOrderRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _rowControls.Count) return;

            foreach (var control in _rowControls[rowIndex])
            {
                pnlTableOrderRows.Controls.Remove(control);
            }
            _rowControls.RemoveAt(rowIndex);

            for (int i = rowIndex; i < _rowControls.Count; i++)
            {
                foreach (var control in _rowControls[i])
                {
                    control.Top -= control.Height + 5;
                }
            }
        }


        private void AcceptOrder(int rowIndex)
        {
            var order = GetOrderFromRowIndex(rowIndex);
            var email = _context.Users.FirstOrDefault(u => u.Name == order.CustomerName)?.Email;
            var name = order.CustomerName;

            if (order != null)
            {
                var result = MessageBox.Show("Are you sure you want to accept this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool orderAccepted = false;

                    if (order.OrderedDate != null )
                    {
                        var carOrder = _context.Orders.FirstOrDefault(co => co.Id == order.OrderId);
                        if (carOrder != null)
                        {
                            carOrder.Option = "Accepted";
                            carOrder.Status = "Processing";
                            _context.SaveChanges();
                            orderAccepted = true;
                            SendmailOrderAcceptance(email, name);
                            MessageBox.Show("Order accepted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (orderAccepted)
                    {
                        RemoveOrderRow(rowIndex);
                        ClearFields();
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid row index.");
            }
        }


        private void SendmailOrderAcceptance(string UserEmail, string UserName)
        {
            MailSender mailSender = new MailSender();
            mailSender.SendMail(UserEmail, UserName, MailSender.EmailType.OrderAcceptance);
        }

















/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////



        private void btnCusReports_Click(object sender, EventArgs e)
        {
            pnlReports.Controls.Clear();

            CrystalReportViewer crViewer = new CrystalReportViewer();

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\Esoft\Top Up\AD\Coursework 1 - project\Project\ABC_car_traders\ABC_car_traders\Reports\CustomerReport.rpt");

            crViewer.ReportSource = reportDocument;
            crViewer.Dock = DockStyle.Fill;

            pnlReports.Controls.Add(crViewer);
        }

        private void btnExportAsPdf_Click(object sender, EventArgs e)
        {
            pnlReports.Controls.Clear();

            CrystalReportViewer crViewer = new CrystalReportViewer();

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\Esoft\Top Up\AD\Coursework 1 - project\Project\ABC_car_traders\ABC_car_traders\Reports\OrderReport.rpt");

            crViewer.ReportSource = reportDocument;
            crViewer.Dock = DockStyle.Fill;

            pnlReports.Controls.Add(crViewer);
        }

        private void btnOrderReports_Click(object sender, EventArgs e)
        {

        }

        private void btnVehicleReports_Click(object sender, EventArgs e)
        {

        }

        private void btnSparePartReports_Click(object sender, EventArgs e)
        {

        }









        //*******************************************DO NOT DELETE************************************************
        //*******************************************DO NOT DELETE************************************************
        //*******************************************DO NOT DELETE************************************************


        //private void gunaChartOrdersCompleted_Load(object sender, EventArgs e)
        //{
        //    // Fetch orders that are not deleted and are completed
        //    var orders = _context.Orders
        //        .Where(o => o.DeletedDate == null && o.Status == "Completed")
        //        .Select(o => new OrderDisplayModel
        //        {
        //            OrderedDate = o.CreatedDate
        //        })
        //        .ToList(); // Execute the query and bring the data into memory

        //    // Grouping the completed orders by month (now that data is in memory)
        //    var ordersGroupedByMonth = orders
        //                            .GroupBy(o => o.OrderedDate.ToString("MMMM"))
        //                            .Select(g => new { Month = g.Key, Count = g.Count() })
        //                            .ToList();

        //    // Clearing existing datasets (if any) in the chart
        //    gunaChartOrdersCompleted.Datasets.Clear();

        //    // Creating a new dataset for the chart
        //    var dataset = new Guna.Charts.WinForms.GunaBarDataset
        //    {
        //        Label = "Completed Orders by Month"
        //    };

        //    // Adding data points to the dataset
        //    foreach (var monthData in ordersGroupedByMonth)
        //    {
        //        dataset.DataPoints.Add(new Guna.Charts.WinForms.LPoint(monthData.Month, monthData.Count));
        //    }

        //    // Adding the dataset to the chart
        //    gunaChartOrdersCompleted.Datasets.Add(dataset);

        //    // Refresh the chart to display the data
        //    gunaChartOrdersCompleted.Update();
        //}

        //*******************************************DO NOT DELETE************************************************
        //*******************************************DO NOT DELETE************************************************
        //*******************************************DO NOT DELETE************************************************


        public void LoadDummyData()
        {
            lblTotalVehicles.Text = "12";
            lblTotalCustomers.Text = "20";
            lblTotalOrders.Text = "15";
        }

        private void gunaChartOrdersCompleted_Load(object sender, EventArgs e)
        {
            // Fetch the completed orders
            List<Order> completedOrders = GetCompletedOrders(); // Replace with your data source method

            // Grouping the completed orders by month
            var ordersGroupedByMonth = completedOrders
                                        .GroupBy(o => o.OrderDate.ToString("MMMM"))
                                        .Select(g => new { Month = g.Key, Count = g.Count() })
                                        .ToList();

            // Clear existing datasets (if any) in the chart
            gunaChartOrdersCompleted.Datasets.Clear();

            //Create a new dataset for the bar chart

           var dataset = new Guna.Charts.WinForms.GunaBarDataset
           {
               //Label = "Data"
           };

            // Add data points to the dataset
            foreach (var monthData in ordersGroupedByMonth)
            {
                dataset.DataPoints.Add(new Guna.Charts.WinForms.LPoint(monthData.Month, monthData.Count));
            }

            // Add the dataset to the chart
            gunaChartOrdersCompleted.Datasets.Add(dataset);

            // Set the chart title
            gunaChartOrdersCompleted.Title.Text = "Monthly Distribution of Completed Orders";
            gunaChartOrdersCompleted.Title.ForeColor = Color.Black; // Customize color if needed

            // Configure the legend
            gunaChartOrdersCompleted.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

            // Refresh the chart to display the data
            gunaChartOrdersCompleted.Update();
        }

        // Example method to simulate fetching completed orders
        private List<Order> GetCompletedOrders()
        {
            // Replace this with your actual data fetching logic, e.g., from a database
            return new List<Order>
    {
        new Order { OrderId = 1, OrderDate = new DateTime(2024, 1, 15) },
        new Order { OrderId = 2, OrderDate = new DateTime(2024, 2, 10) },
        new Order { OrderId = 3, OrderDate = new DateTime(2024, 1, 25) },
        new Order { OrderId = 4, OrderDate = new DateTime(2024, 3, 5) },
        new Order { OrderId = 5, OrderDate = new DateTime(2024, 2, 22) },
        new Order { OrderId = 6, OrderDate = new DateTime(2024, 4, 18) },
        new Order { OrderId = 7, OrderDate = new DateTime(2024, 5, 12) },
        new Order { OrderId = 8, OrderDate = new DateTime(2024, 6, 30) },
        new Order { OrderId = 9, OrderDate = new DateTime(2024, 4, 8) },
        new Order { OrderId = 10, OrderDate = new DateTime(2024, 6, 19) },
    };
        }



        // Example method to simulate fetching orders by month and year
        private List<Order> GetOrdersByMonthAndYear(int month, int year)
        {
            // Replace this with your actual data fetching logic, e.g., from a database
            return new List<Order>
    {
        new Order { OrderId = 1, OrderDate = new DateTime(year, month, 15), Status = "Completed" },
        new Order { OrderId = 2, OrderDate = new DateTime(year, month, 10), Status = "Rejected" },
        new Order { OrderId = 3, OrderDate = new DateTime(year, month, 25), Status = "Completed" },
        new Order { OrderId = 4, OrderDate = new DateTime(year, month, 5), Status = "Processing" },
        new Order { OrderId = 5, OrderDate = new DateTime(year, month, 22), Status = "Completed" },
    };
        }

        // Sample Order class with Status field
        public class Order
        {
            public int OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; } 
        }

        private void gunaChartOrdersStatus_Load(object sender, EventArgs e)
        {
            int targetMonth = 8; // For example, August
            int targetYear = 2024;

            // Fetch orders for the specific month and year
            List<Order> orders = GetOrdersByMonthAndYear(targetMonth, targetYear);

            // Group the orders by status
            var ordersGroupedByStatus = orders
                                        .GroupBy(o => o.Status)
                                        .Select(g => new { Status = g.Key, Count = g.Count() })
                                        .ToList();

            // Clear existing datasets in the chart
            gunaChartOrdersStatus.Datasets.Clear();

            // Create a new dataset for the pie chart
            var pieDataset = new Guna.Charts.WinForms.GunaPieDataset();

            // Add data points with specific labels for each status
            foreach (var statusData in ordersGroupedByStatus)
            {
                pieDataset.DataPoints.Add(new Guna.Charts.WinForms.LPoint(statusData.Status, statusData.Count)
                {
                    Label = statusData.Status // This will be used as the legend label
                });
            }

            // Add the dataset to the chart
            gunaChartOrdersStatus.Datasets.Add(pieDataset);

            // Set the chart title
            gunaChartOrdersStatus.Title.Text = "Order Status Distribution for " + new DateTime(targetYear, targetMonth, 1).ToString("MMMM yyyy");
            gunaChartOrdersStatus.Title.ForeColor = Color.Black;

            // Configure the legend to show the status labels
            gunaChartOrdersStatus.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

            // Refresh the chart to display the data
            gunaChartOrdersStatus.Update();
        }

        




        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            var adminname = txtAdminName.Text.Trim();
            var adminemail = txtAdminEmail.Text.Trim();
            var adminphone = txtAdminPhone.Text.Trim();
            var adminUsername = txtAdminUsername.Text.Trim();
            var adminpassword = txtAdminPW.Text.Trim();

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminpassword);

            if (string.IsNullOrEmpty(adminname) || string.IsNullOrEmpty(adminemail) || string.IsNullOrEmpty(adminphone) || string.IsNullOrEmpty(adminUsername) || string.IsNullOrEmpty(adminpassword))
            {
                MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var admin = new Admin
                {
                    Id = Guid.NewGuid(),
                    Name = adminname,
                    Email = adminemail,
                    Username = adminUsername,
                    Password = hashedPassword,
                   
                };
                _context.Admins.Add(admin);
                _context.SaveChanges();

                MessageBox.Show("Admin details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the admin details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
