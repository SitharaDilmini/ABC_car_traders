using ABC_Car_Traders.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using BCrypt.Net;
using ABC_Car_Traders.Models;
using ABC_Car_Traders.Utils;
using System.Drawing;
using FluentValidation;
using ABC_car_traders.Models;
using ABC_car_traders.Validations;


namespace ABC_Car_Traders
{
    public partial class login_form : Form
    {
        private AppDbContext _context;
        private string verificationToken;
        private string userEmail;
        private string userName;
        private int loginAttempts = 0;

        public login_form()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void Admin_login_form_Load(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            pnlSignup.Visible = false;
            pnlVerifyEmail.Visible = false;
            pnlResetPW.Visible = false;
        }


        //-------------------------------------- Sign Up Process --------------------------------------
        //---------------------------------------------------------------------------------------------
        private UserInputModel GetUserInput()
        {
            return new UserInputModel
            {
                Name = txtCusName.Text,
                Email = txtCusEmail.Text,
                Address = txtCusAddress.Text,
                Phone = txtCusPhone.Text,
                Password = txtCusPW.Text,
                PasswordConfirm = txtCusPWConfirm.Text
            };
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            lblSignupError.Text = string.Empty;

            var userInput = GetUserInput();

            var validator = new SignupValidator();
            var validationResult = validator.Validate(userInput);

            if (!validationResult.IsValid)
            {
                MessageBox.Show(string.Join("\n", validationResult.Errors.Select(error => error.ErrorMessage)), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userEmail = userInput.Email;
            userName = userInput.Name;

            // Check if the user already exists
            var userExists = _context.Users.Any(u => u.Email == userInput.Email);
            if (userExists)
            {
                lblSignupError.Text = "User already exists. Please login.";
                return;
            }

            MailSender mailSender = new MailSender();
            verificationToken = mailSender.SendMail(userEmail, userName, MailSender.EmailType.Verification);
            pnlVerifyEmail.Visible = true;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtVerificationCode.Text == verificationToken)
            {
                var userInput = GetUserInput();

                // Hash the password
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userInput.Password);

                // Add the user to the database
                User newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Name = userInput.Name,
                    Email = userInput.Email,
                    Address = userInput.Address,
                    Phone = userInput.Phone,
                    Password = hashedPassword,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                clear_fields();
                pnlVerifyEmail.Visible = false;
                pnlSignup.Visible = false;
                pnlLogin.Visible = true;
            }
            else
            {
                MessageBox.Show("Verification code is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //-------------------------------------- Login Process ----------------------------------------
        //---------------------------------------------------------------------------------------------
        private UserInputModel GetLoginInput()
        {
            return new UserInputModel
            {
                Username = txtUN.Text,
                Password = txtPW.Text
            };
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Clear any previous error messages
            lblErrorMsg.Text = string.Empty;

            var loginInput = GetLoginInput();

            // Validate login input using FluentValidation
            var validator = new LoginValidator();
            var validationResult = validator.Validate(loginInput);

            if (!validationResult.IsValid)
            {
                lblErrorMsg.Text = string.Join("\n", validationResult.Errors.Select(error => error.ErrorMessage));
                return;
            }

            // Check for admin credentials
            var admin = _context.Admins.SingleOrDefault(a => a.Username == loginInput.Username && a.Password == loginInput.Password);
            if (admin != null)
            {
                Admin_dashboard admin_dashboard = new Admin_dashboard(admin.Name);
                admin_dashboard.Show();
                this.Hide();
                return;
            }

            // Check for user credentials
            var user = _context.Users.SingleOrDefault(u => u.Email == loginInput.Username);
            if (user != null)
            {
                if (user.DeletedDate != null)
                {
                    MessageBox.Show(
                        "Your account has been deleted.\n\n" +
                        "If you have any questions, please contact us.\n" +
                        "Phone: 071 866 54 54",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                if (BCrypt.Net.BCrypt.Verify(loginInput.Password, user.Password))
                {
                    Main_customer_form main_customer_Form = new Main_customer_form(user.Name);
                    main_customer_Form.Show();
                    this.Hide();
                    return;
                }
            }

            loginAttempts++;
            if (loginAttempts >= 3)
            {
                MessageBox.Show(
                    "You have exceeded the maximum number of attempts.\n\n" +
                    "If you don't have an account, please sign up.\n" +
                    "If you have forgotten your password, you can reset it.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // If no user or admin is found, show an error message
            lblErrorMsg.Text = "Username or Password Incorrect";

            clear_fields();
        }



        //-------------------------------------- Other Functions --------------------------------------
        //---------------------------------------------------------------------------------------------
        private void clear_fields()
        {
            txtCusName.Text = "";
            txtCusEmail.Text = "";
            txtCusAddress.Text = "";
            txtCusPW.Text = "";
            txtCusPWConfirm.Text = "";
            txtUN.Text = "";
            txtPW.Text = "";
            txtVerificationCode.Text = "";
        }

        private void Login_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void pnlLogin_btnSignup_select_Click(object sender, EventArgs e)
        {
            pnlSignup.Visible = true;
            pnlLogin.Visible = false;
            pnlVerifyEmail.Visible = false;
        }

        private void pnlSignup_btnLogin_select_Click_1(object sender, EventArgs e)
        {
            pnlSignup.Visible = false;
            pnlLogin.Visible = true;
            pnlVerifyEmail.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear_fields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResetConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
