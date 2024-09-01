using System.Windows.Forms;

namespace ABC_Car_Traders
{
    partial class login_form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_form));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxShowPassword = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogin_btnSignup_select = new Guna.UI2.WinForms.Guna2Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnResetPW = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.txtPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUN = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSignup = new System.Windows.Forms.Panel();
            this.txtCusPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSignupError = new System.Windows.Forms.Label();
            this.pnlSignup_btnLogin_select = new Guna.UI2.WinForms.Guna2Button();
            this.btnSignup = new Guna.UI2.WinForms.Guna2Button();
            this.txtCusPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusPWConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlVerifyEmail = new System.Windows.Forms.Panel();
            this.btnVerify = new Guna.UI2.WinForms.Guna2Button();
            this.txtVerificationCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlResetPW = new Guna.UI2.WinForms.Guna2Panel();
            this.lblErrorlblResetPWError = new System.Windows.Forms.Label();
            this.btnCancelResetPW = new Guna.UI2.WinForms.Guna2Button();
            this.btnResetConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.txtNewPWConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNewPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEmaiResetPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlSignup.SuspendLayout();
            this.pnlVerifyEmail.SuspendLayout();
            this.pnlResetPW.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(57, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 274);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 220);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(518, 393);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 614);
            this.panel1.TabIndex = 9;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.label13);
            this.pnlLogin.Controls.Add(this.checkBoxShowPassword);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.pnlLogin_btnSignup_select);
            this.pnlLogin.Controls.Add(this.label10);
            this.pnlLogin.Controls.Add(this.btnResetPW);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblErrorMsg);
            this.pnlLogin.Controls.Add(this.txtPW);
            this.pnlLogin.Controls.Add(this.txtUN);
            this.pnlLogin.Controls.Add(this.label9);
            this.pnlLogin.Controls.Add(this.label5);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Location = new System.Drawing.Point(519, -2);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(502, 610);
            this.pnlLogin.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(67, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 15);
            this.label13.TabIndex = 30;
            this.label13.Text = "Show Password";
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBoxShowPassword.CheckedState.BorderRadius = 2;
            this.checkBoxShowPassword.CheckedState.BorderThickness = 0;
            this.checkBoxShowPassword.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(48, 308);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(15, 15);
            this.checkBoxShowPassword.TabIndex = 29;
            this.checkBoxShowPassword.Text = "guna2CustomCheckBox1";
            this.checkBoxShowPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkBoxShowPassword.UncheckedState.BorderRadius = 2;
            this.checkBoxShowPassword.UncheckedState.BorderThickness = 0;
            this.checkBoxShowPassword.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 5;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(339, 545);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 39);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "EXIT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlLogin_btnSignup_select
            // 
            this.pnlLogin_btnSignup_select.BorderRadius = 5;
            this.pnlLogin_btnSignup_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLogin_btnSignup_select.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlLogin_btnSignup_select.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.pnlLogin_btnSignup_select.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.pnlLogin_btnSignup_select.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.pnlLogin_btnSignup_select.FillColor = System.Drawing.Color.Maroon;
            this.pnlLogin_btnSignup_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLogin_btnSignup_select.ForeColor = System.Drawing.Color.White;
            this.pnlLogin_btnSignup_select.Location = new System.Drawing.Point(48, 460);
            this.pnlLogin_btnSignup_select.Name = "pnlLogin_btnSignup_select";
            this.pnlLogin_btnSignup_select.Size = new System.Drawing.Size(406, 46);
            this.pnlLogin_btnSignup_select.TabIndex = 26;
            this.pnlLogin_btnSignup_select.Text = "SIGN UP";
            this.pnlLogin_btnSignup_select.Click += new System.EventHandler(this.pnlLogin_btnSignup_select_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(44, 437);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Don\'t have an account ? ";
            // 
            // btnResetPW
            // 
            this.btnResetPW.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnResetPW.BorderRadius = 5;
            this.btnResetPW.BorderThickness = 2;
            this.btnResetPW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPW.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetPW.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetPW.FillColor = System.Drawing.Color.Transparent;
            this.btnResetPW.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnResetPW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnResetPW.Location = new System.Drawing.Point(48, 359);
            this.btnResetPW.Name = "btnResetPW";
            this.btnResetPW.Size = new System.Drawing.Size(192, 52);
            this.btnResetPW.TabIndex = 24;
            this.btnResetPW.Text = "RESET PASSWORD";
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(262, 359);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(192, 52);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(45, 332);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(0, 16);
            this.lblErrorMsg.TabIndex = 22;
            // 
            // txtPW
            // 
            this.txtPW.BorderRadius = 5;
            this.txtPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPW.DefaultText = "";
            this.txtPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPW.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPW.ForeColor = System.Drawing.Color.DimGray;
            this.txtPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPW.Location = new System.Drawing.Point(48, 249);
            this.txtPW.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '●';
            this.txtPW.PlaceholderText = "Enter your password";
            this.txtPW.SelectedText = "";
            this.txtPW.Size = new System.Drawing.Size(406, 53);
            this.txtPW.TabIndex = 2;
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // txtUN
            // 
            this.txtUN.BorderRadius = 5;
            this.txtUN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUN.DefaultText = "";
            this.txtUN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUN.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUN.ForeColor = System.Drawing.Color.DimGray;
            this.txtUN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUN.Location = new System.Drawing.Point(48, 142);
            this.txtUN.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUN.Name = "txtUN";
            this.txtUN.PasswordChar = '\0';
            this.txtUN.PlaceholderText = "Enter your email or username";
            this.txtUN.SelectedText = "";
            this.txtUN.Size = new System.Drawing.Size(406, 53);
            this.txtUN.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(161, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 41);
            this.label9.TabIndex = 19;
            this.label9.Text = "Welcome!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username / Email";
            // 
            // pnlSignup
            // 
            this.pnlSignup.Controls.Add(this.txtCusPhone);
            this.pnlSignup.Controls.Add(this.label12);
            this.pnlSignup.Controls.Add(this.lblSignupError);
            this.pnlSignup.Controls.Add(this.pnlSignup_btnLogin_select);
            this.pnlSignup.Controls.Add(this.btnSignup);
            this.pnlSignup.Controls.Add(this.txtCusPW);
            this.pnlSignup.Controls.Add(this.txtCusEmail);
            this.pnlSignup.Controls.Add(this.txtCusAddress);
            this.pnlSignup.Controls.Add(this.txtCusPWConfirm);
            this.pnlSignup.Controls.Add(this.txtCusName);
            this.pnlSignup.Controls.Add(this.label8);
            this.pnlSignup.Controls.Add(this.label7);
            this.pnlSignup.Controls.Add(this.label6);
            this.pnlSignup.Controls.Add(this.label4);
            this.pnlSignup.Controls.Add(this.label2);
            this.pnlSignup.Controls.Add(this.label1);
            this.pnlSignup.Location = new System.Drawing.Point(-1, -2);
            this.pnlSignup.Name = "pnlSignup";
            this.pnlSignup.Size = new System.Drawing.Size(1022, 610);
            this.pnlSignup.TabIndex = 10;
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.BorderRadius = 5;
            this.txtCusPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusPhone.DefaultText = "";
            this.txtCusPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCusPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPhone.Location = new System.Drawing.Point(551, 142);
            this.txtCusPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.PasswordChar = '\0';
            this.txtCusPhone.PlaceholderText = "";
            this.txtCusPhone.SelectedText = "";
            this.txtCusPhone.Size = new System.Drawing.Size(347, 53);
            this.txtCusPhone.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(547, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 25);
            this.label12.TabIndex = 29;
            this.label12.Text = "Phone";
            // 
            // lblSignupError
            // 
            this.lblSignupError.AutoSize = true;
            this.lblSignupError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblSignupError.ForeColor = System.Drawing.Color.Red;
            this.lblSignupError.Location = new System.Drawing.Point(550, 426);
            this.lblSignupError.Name = "lblSignupError";
            this.lblSignupError.Size = new System.Drawing.Size(0, 15);
            this.lblSignupError.TabIndex = 27;
            // 
            // pnlSignup_btnLogin_select
            // 
            this.pnlSignup_btnLogin_select.BorderRadius = 5;
            this.pnlSignup_btnLogin_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSignup_btnLogin_select.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlSignup_btnLogin_select.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.pnlSignup_btnLogin_select.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.pnlSignup_btnLogin_select.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.pnlSignup_btnLogin_select.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlSignup_btnLogin_select.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.pnlSignup_btnLogin_select.ForeColor = System.Drawing.Color.White;
            this.pnlSignup_btnLogin_select.Location = new System.Drawing.Point(132, 462);
            this.pnlSignup_btnLogin_select.Name = "pnlSignup_btnLogin_select";
            this.pnlSignup_btnLogin_select.Size = new System.Drawing.Size(347, 53);
            this.pnlSignup_btnLogin_select.TabIndex = 26;
            this.pnlSignup_btnLogin_select.Text = "BACK";
            this.pnlSignup_btnLogin_select.Click += new System.EventHandler(this.pnlSignup_btnLogin_select_Click_1);
            // 
            // btnSignup
            // 
            this.btnSignup.BorderRadius = 5;
            this.btnSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignup.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignup.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(553, 462);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(347, 53);
            this.btnSignup.TabIndex = 10;
            this.btnSignup.Text = "CREATE ACCOUNT";
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtCusPW
            // 
            this.txtCusPW.BorderRadius = 5;
            this.txtCusPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusPW.DefaultText = "";
            this.txtCusPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPW.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCusPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPW.Location = new System.Drawing.Point(552, 251);
            this.txtCusPW.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusPW.Name = "txtCusPW";
            this.txtCusPW.PasswordChar = '●';
            this.txtCusPW.PlaceholderText = "";
            this.txtCusPW.SelectedText = "";
            this.txtCusPW.Size = new System.Drawing.Size(347, 52);
            this.txtCusPW.TabIndex = 8;
            this.txtCusPW.UseSystemPasswordChar = true;
            // 
            // txtCusEmail
            // 
            this.txtCusEmail.BorderRadius = 5;
            this.txtCusEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusEmail.DefaultText = "";
            this.txtCusEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCusEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusEmail.Location = new System.Drawing.Point(132, 251);
            this.txtCusEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusEmail.Name = "txtCusEmail";
            this.txtCusEmail.PasswordChar = '\0';
            this.txtCusEmail.PlaceholderText = "";
            this.txtCusEmail.SelectedText = "";
            this.txtCusEmail.Size = new System.Drawing.Size(347, 53);
            this.txtCusEmail.TabIndex = 5;
            // 
            // txtCusAddress
            // 
            this.txtCusAddress.BorderRadius = 5;
            this.txtCusAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusAddress.DefaultText = "";
            this.txtCusAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCusAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusAddress.Location = new System.Drawing.Point(132, 361);
            this.txtCusAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusAddress.Multiline = true;
            this.txtCusAddress.Name = "txtCusAddress";
            this.txtCusAddress.PasswordChar = '\0';
            this.txtCusAddress.PlaceholderText = "";
            this.txtCusAddress.SelectedText = "";
            this.txtCusAddress.Size = new System.Drawing.Size(347, 53);
            this.txtCusAddress.TabIndex = 6;
            // 
            // txtCusPWConfirm
            // 
            this.txtCusPWConfirm.BorderRadius = 5;
            this.txtCusPWConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusPWConfirm.DefaultText = "";
            this.txtCusPWConfirm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusPWConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusPWConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPWConfirm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusPWConfirm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPWConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCusPWConfirm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusPWConfirm.Location = new System.Drawing.Point(552, 361);
            this.txtCusPWConfirm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusPWConfirm.Name = "txtCusPWConfirm";
            this.txtCusPWConfirm.PasswordChar = '●';
            this.txtCusPWConfirm.PlaceholderText = "";
            this.txtCusPWConfirm.SelectedText = "";
            this.txtCusPWConfirm.Size = new System.Drawing.Size(347, 53);
            this.txtCusPWConfirm.TabIndex = 9;
            this.txtCusPWConfirm.UseSystemPasswordChar = true;
            // 
            // txtCusName
            // 
            this.txtCusName.BorderRadius = 5;
            this.txtCusName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCusName.DefaultText = "";
            this.txtCusName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCusName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusName.Location = new System.Drawing.Point(132, 142);
            this.txtCusName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.PasswordChar = '\0';
            this.txtCusName.PlaceholderText = "";
            this.txtCusName.SelectedText = "";
            this.txtCusName.Size = new System.Drawing.Size(347, 53);
            this.txtCusName.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(414, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 46);
            this.label8.TabIndex = 18;
            this.label8.Text = "Welcome!";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(128, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(128, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(548, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(548, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // pnlVerifyEmail
            // 
            this.pnlVerifyEmail.Controls.Add(this.btnVerify);
            this.pnlVerifyEmail.Controls.Add(this.txtVerificationCode);
            this.pnlVerifyEmail.Controls.Add(this.label11);
            this.pnlVerifyEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlVerifyEmail.Location = new System.Drawing.Point(-1, 0);
            this.pnlVerifyEmail.Name = "pnlVerifyEmail";
            this.pnlVerifyEmail.Size = new System.Drawing.Size(1022, 605);
            this.pnlVerifyEmail.TabIndex = 16;
            // 
            // btnVerify
            // 
            this.btnVerify.BorderRadius = 6;
            this.btnVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(364, 424);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(307, 54);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "VERIFY";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.BorderRadius = 5;
            this.txtVerificationCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVerificationCode.DefaultText = "";
            this.txtVerificationCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVerificationCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVerificationCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerificationCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerificationCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerificationCode.Font = new System.Drawing.Font("Segoe UI", 50F);
            this.txtVerificationCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerificationCode.Location = new System.Drawing.Point(247, 209);
            this.txtVerificationCode.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.PasswordChar = '\0';
            this.txtVerificationCode.PlaceholderText = "";
            this.txtVerificationCode.SelectedText = "";
            this.txtVerificationCode.Size = new System.Drawing.Size(534, 120);
            this.txtVerificationCode.TabIndex = 1;
            this.txtVerificationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(165, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(704, 57);
            this.label11.TabIndex = 2;
            this.label11.Text = "Enter Your Verification Token Here";
            // 
            // pnlResetPW
            // 
            this.pnlResetPW.Controls.Add(this.lblErrorlblResetPWError);
            this.pnlResetPW.Controls.Add(this.btnCancelResetPW);
            this.pnlResetPW.Controls.Add(this.btnResetConfirm);
            this.pnlResetPW.Controls.Add(this.txtNewPWConfirm);
            this.pnlResetPW.Controls.Add(this.label17);
            this.pnlResetPW.Controls.Add(this.txtNewPW);
            this.pnlResetPW.Controls.Add(this.label16);
            this.pnlResetPW.Controls.Add(this.txtEmaiResetPW);
            this.pnlResetPW.Controls.Add(this.label15);
            this.pnlResetPW.Controls.Add(this.label14);
            this.pnlResetPW.Location = new System.Drawing.Point(0, 0);
            this.pnlResetPW.Name = "pnlResetPW";
            this.pnlResetPW.Size = new System.Drawing.Size(1021, 605);
            this.pnlResetPW.TabIndex = 17;
            // 
            // lblErrorlblResetPWError
            // 
            this.lblErrorlblResetPWError.AutoSize = true;
            this.lblErrorlblResetPWError.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblErrorlblResetPWError.ForeColor = System.Drawing.Color.Red;
            this.lblErrorlblResetPWError.Location = new System.Drawing.Point(246, 445);
            this.lblErrorlblResetPWError.Name = "lblErrorlblResetPWError";
            this.lblErrorlblResetPWError.Size = new System.Drawing.Size(0, 15);
            this.lblErrorlblResetPWError.TabIndex = 9;
            // 
            // btnCancelResetPW
            // 
            this.btnCancelResetPW.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCancelResetPW.BorderRadius = 5;
            this.btnCancelResetPW.BorderThickness = 3;
            this.btnCancelResetPW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelResetPW.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelResetPW.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelResetPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelResetPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelResetPW.FillColor = System.Drawing.Color.White;
            this.btnCancelResetPW.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancelResetPW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCancelResetPW.Location = new System.Drawing.Point(531, 484);
            this.btnCancelResetPW.Name = "btnCancelResetPW";
            this.btnCancelResetPW.Size = new System.Drawing.Size(259, 53);
            this.btnCancelResetPW.TabIndex = 8;
            this.btnCancelResetPW.Text = "CANCEL";
            // 
            // btnResetConfirm
            // 
            this.btnResetConfirm.BorderRadius = 5;
            this.btnResetConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetConfirm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnResetConfirm.ForeColor = System.Drawing.Color.White;
            this.btnResetConfirm.Location = new System.Drawing.Point(250, 484);
            this.btnResetConfirm.Name = "btnResetConfirm";
            this.btnResetConfirm.Size = new System.Drawing.Size(259, 53);
            this.btnResetConfirm.TabIndex = 7;
            this.btnResetConfirm.Text = "RESET";
            this.btnResetConfirm.Click += new System.EventHandler(this.btnResetConfirm_Click);
            // 
            // txtNewPWConfirm
            // 
            this.txtNewPWConfirm.BorderRadius = 5;
            this.txtNewPWConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPWConfirm.DefaultText = "";
            this.txtNewPWConfirm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPWConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPWConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPWConfirm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPWConfirm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPWConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPWConfirm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPWConfirm.Location = new System.Drawing.Point(250, 379);
            this.txtNewPWConfirm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNewPWConfirm.Name = "txtNewPWConfirm";
            this.txtNewPWConfirm.PasswordChar = '●';
            this.txtNewPWConfirm.PlaceholderText = "";
            this.txtNewPWConfirm.SelectedText = "";
            this.txtNewPWConfirm.Size = new System.Drawing.Size(540, 50);
            this.txtNewPWConfirm.TabIndex = 6;
            this.txtNewPWConfirm.UseSystemPasswordChar = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(246, 350);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(146, 23);
            this.label17.TabIndex = 5;
            this.label17.Text = "Confirm Password";
            // 
            // txtNewPW
            // 
            this.txtNewPW.BorderRadius = 5;
            this.txtNewPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPW.DefaultText = "";
            this.txtNewPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPW.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPW.Location = new System.Drawing.Point(250, 275);
            this.txtNewPW.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNewPW.Name = "txtNewPW";
            this.txtNewPW.PasswordChar = '●';
            this.txtNewPW.PlaceholderText = "";
            this.txtNewPW.SelectedText = "";
            this.txtNewPW.Size = new System.Drawing.Size(540, 50);
            this.txtNewPW.TabIndex = 4;
            this.txtNewPW.UseSystemPasswordChar = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(246, 246);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 23);
            this.label16.TabIndex = 3;
            this.label16.Text = "Enter New Password";
            // 
            // txtEmaiResetPW
            // 
            this.txtEmaiResetPW.BorderRadius = 5;
            this.txtEmaiResetPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmaiResetPW.DefaultText = "";
            this.txtEmaiResetPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmaiResetPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmaiResetPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmaiResetPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmaiResetPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmaiResetPW.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmaiResetPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmaiResetPW.Location = new System.Drawing.Point(367, 133);
            this.txtEmaiResetPW.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmaiResetPW.Name = "txtEmaiResetPW";
            this.txtEmaiResetPW.PasswordChar = '\0';
            this.txtEmaiResetPW.PlaceholderText = "";
            this.txtEmaiResetPW.SelectedText = "";
            this.txtEmaiResetPW.Size = new System.Drawing.Size(423, 50);
            this.txtEmaiResetPW.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(246, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 23);
            this.label15.TabIndex = 1;
            this.label15.Text = "Your Email";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(360, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(314, 46);
            this.label14.TabIndex = 0;
            this.label14.Text = "RESET PASSWORD";
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 609);
            this.ControlBox = false;
            this.Controls.Add(this.pnlResetPW);
            this.Controls.Add(this.pnlVerifyEmail);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlSignup);
            this.Controls.Add(this.panel1);
            this.Name = "login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login_form";
            this.Load += new System.EventHandler(this.Admin_login_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlSignup.ResumeLayout(false);
            this.pnlSignup.PerformLayout();
            this.pnlVerifyEmail.ResumeLayout(false);
            this.pnlVerifyEmail.PerformLayout();
            this.pnlResetPW.ResumeLayout(false);
            this.pnlResetPW.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlSignup;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlVerifyEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtUN;
        private Label lblErrorMsg;
        private Guna.UI2.WinForms.Guna2TextBox txtPW;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnResetPW;
        private Guna.UI2.WinForms.Guna2Button pnlLogin_btnSignup_select;
        private Label label10;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2TextBox txtCusName;
        private Guna.UI2.WinForms.Guna2TextBox txtCusEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtCusAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtCusPWConfirm;
        private Guna.UI2.WinForms.Guna2TextBox txtCusPW;
        private Guna.UI2.WinForms.Guna2Button btnSignup;
        private Guna.UI2.WinForms.Guna2Button pnlSignup_btnLogin_select;
        private Label lblSignupError;
        private Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtVerificationCode;
        private Guna.UI2.WinForms.Guna2Button btnVerify;
        private Guna.UI2.WinForms.Guna2TextBox txtCusPhone;
        private Label label12;
        private Label label13;
        private Guna.UI2.WinForms.Guna2CustomCheckBox checkBoxShowPassword;
        private Guna.UI2.WinForms.Guna2Panel pnlResetPW;
        private Label label14;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPWConfirm;
        private Label label17;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPW;
        private Label label16;
        private Guna.UI2.WinForms.Guna2TextBox txtEmaiResetPW;
        private Label label15;
        private Guna.UI2.WinForms.Guna2Button btnResetConfirm;
        private Guna.UI2.WinForms.Guna2Button btnCancelResetPW;
        private Label lblErrorlblResetPWError;
    }
}
