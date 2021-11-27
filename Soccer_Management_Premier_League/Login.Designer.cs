namespace Soccer_Management_Premier_League
{
    partial class Login

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ChooseUser = new Guna.UI2.WinForms.Guna2ComboBox();
            this.UserTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.UserPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.UserLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PassTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.PassPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PassLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ForgotPass = new Guna.UI2.WinForms.Guna2Button();
            this.PassCheck = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SignUpButton = new Guna.UI2.WinForms.Guna2Button();
            this.LoginButton = new Guna.UI2.WinForms.Guna2Button();
            this.UserPanel.SuspendLayout();
            this.PassPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseUser
            // 
            this.ChooseUser.BackColor = System.Drawing.Color.Transparent;
            this.ChooseUser.BorderRadius = 5;
            this.ChooseUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ChooseUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseUser.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChooseUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChooseUser.FocusedState.Parent = this.ChooseUser;
            this.ChooseUser.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ChooseUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ChooseUser.HoverState.Parent = this.ChooseUser;
            this.ChooseUser.ItemHeight = 30;
            this.ChooseUser.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.ChooseUser.ItemsAppearance.Parent = this.ChooseUser;
            this.ChooseUser.Location = new System.Drawing.Point(775, 12);
            this.ChooseUser.Name = "ChooseUser";
            this.ChooseUser.ShadowDecoration.Parent = this.ChooseUser;
            this.ChooseUser.Size = new System.Drawing.Size(97, 36);
            this.ChooseUser.TabIndex = 10;
            // 
            // UserTextbox
            // 
            this.UserTextbox.BackColor = System.Drawing.Color.Transparent;
            this.UserTextbox.BorderRadius = 3;
            this.UserTextbox.BorderThickness = 0;
            this.UserTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserTextbox.DefaultText = "";
            this.UserTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UserTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UserTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserTextbox.DisabledState.Parent = this.UserTextbox;
            this.UserTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserTextbox.FocusedState.Parent = this.UserTextbox;
            this.UserTextbox.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.UserTextbox.ForeColor = System.Drawing.Color.Black;
            this.UserTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserTextbox.HoverState.Parent = this.UserTextbox;
            this.UserTextbox.Location = new System.Drawing.Point(5, 5);
            this.UserTextbox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.UserTextbox.Name = "UserTextbox";
            this.UserTextbox.PasswordChar = '\0';
            this.UserTextbox.PlaceholderText = "Click to write";
            this.UserTextbox.SelectedText = "";
            this.UserTextbox.ShadowDecoration.Parent = this.UserTextbox;
            this.UserTextbox.Size = new System.Drawing.Size(457, 34);
            this.UserTextbox.TabIndex = 1;
            // 
            // UserPanel
            // 
            this.UserPanel.BackColor = System.Drawing.Color.Transparent;
            this.UserPanel.Controls.Add(this.UserTextbox);
            this.UserPanel.Location = new System.Drawing.Point(216, 242);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(465, 79);
            this.UserPanel.TabIndex = 4;
            // 
            // UserLabel
            // 
            this.UserLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.ForeColor = System.Drawing.Color.White;
            this.UserLabel.Location = new System.Drawing.Point(3, 3);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(51, 26);
            this.UserLabel.TabIndex = 0;
            this.UserLabel.Text = "User:";
            // 
            // PassTextbox
            // 
            this.PassTextbox.BackColor = System.Drawing.Color.Transparent;
            this.PassTextbox.BorderRadius = 3;
            this.PassTextbox.BorderThickness = 0;
            this.PassTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PassTextbox.DefaultText = "";
            this.PassTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PassTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PassTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PassTextbox.DisabledState.Parent = this.PassTextbox;
            this.PassTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PassTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PassTextbox.FocusedState.Parent = this.PassTextbox;
            this.PassTextbox.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.PassTextbox.ForeColor = System.Drawing.Color.Black;
            this.PassTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PassTextbox.HoverState.Parent = this.PassTextbox;
            this.PassTextbox.Location = new System.Drawing.Point(5, 5);
            this.PassTextbox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PassTextbox.Name = "PassTextbox";
            this.PassTextbox.PasswordChar = '\0';
            this.PassTextbox.PlaceholderText = "Click to write";
            this.PassTextbox.SelectedText = "";
            this.PassTextbox.ShadowDecoration.Parent = this.PassTextbox;
            this.PassTextbox.Size = new System.Drawing.Size(457, 34);
            this.PassTextbox.TabIndex = 3;
            this.PassTextbox.UseSystemPasswordChar = true;
            // 
            // PassPanel
            // 
            this.PassPanel.BackColor = System.Drawing.Color.Transparent;
            this.PassPanel.Controls.Add(this.PassTextbox);
            this.PassPanel.Location = new System.Drawing.Point(216, 327);
            this.PassPanel.Name = "PassPanel";
            this.PassPanel.Size = new System.Drawing.Size(465, 80);
            this.PassPanel.TabIndex = 5;
            // 
            // PassLabel
            // 
            this.PassLabel.BackColor = System.Drawing.Color.Transparent;
            this.PassLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassLabel.ForeColor = System.Drawing.Color.White;
            this.PassLabel.Location = new System.Drawing.Point(3, 3);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(96, 26);
            this.PassLabel.TabIndex = 2;
            this.PassLabel.Text = "Password:";
            // 
            // ForgotPass
            // 
            this.ForgotPass.BackColor = System.Drawing.Color.Transparent;
            this.ForgotPass.CheckedState.Parent = this.ForgotPass;
            this.ForgotPass.CustomImages.Parent = this.ForgotPass;
            this.ForgotPass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ForgotPass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ForgotPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ForgotPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ForgotPass.DisabledState.Parent = this.ForgotPass;
            this.ForgotPass.FillColor = System.Drawing.Color.Transparent;
            this.ForgotPass.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPass.ForeColor = System.Drawing.Color.White;
            this.ForgotPass.HoverState.Parent = this.ForgotPass;
            this.ForgotPass.Location = new System.Drawing.Point(561, 413);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.ShadowDecoration.Parent = this.ForgotPass;
            this.ForgotPass.Size = new System.Drawing.Size(117, 29);
            this.ForgotPass.TabIndex = 9;
            this.ForgotPass.Text = "Forgot Password?";
            this.ForgotPass.UseTransparentBackground = true;
            this.ForgotPass.Click += new System.EventHandler(this.ForgotPass_Click);
            // 
            // PassCheck
            // 
            this.PassCheck.AutoSize = true;
            this.PassCheck.BackColor = System.Drawing.Color.Transparent;
            this.PassCheck.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.PassCheck.CheckedState.BorderRadius = 0;
            this.PassCheck.CheckedState.BorderThickness = 0;
            this.PassCheck.CheckedState.FillColor = System.Drawing.Color.White;
            this.PassCheck.CheckMarkColor = System.Drawing.Color.Black;
            this.PassCheck.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassCheck.ForeColor = System.Drawing.Color.White;
            this.PassCheck.Location = new System.Drawing.Point(216, 413);
            this.PassCheck.Name = "PassCheck";
            this.PassCheck.Size = new System.Drawing.Size(136, 19);
            this.PassCheck.TabIndex = 7;
            this.PassCheck.Text = "Remember Password";
            this.PassCheck.UncheckedState.BorderColor = System.Drawing.Color.White;
            this.PassCheck.UncheckedState.BorderRadius = 0;
            this.PassCheck.UncheckedState.BorderThickness = 0;
            this.PassCheck.UncheckedState.FillColor = System.Drawing.Color.White;
            this.PassCheck.UseVisualStyleBackColor = false;
            // 
            // SignUpButton
            // 
            this.SignUpButton.BackColor = System.Drawing.Color.Transparent;
            this.SignUpButton.BorderColor = System.Drawing.Color.White;
            this.SignUpButton.BorderThickness = 1;
            this.SignUpButton.CheckedState.Parent = this.SignUpButton;
            this.SignUpButton.CustomImages.Parent = this.SignUpButton;
            this.SignUpButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SignUpButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SignUpButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SignUpButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SignUpButton.DisabledState.Parent = this.SignUpButton;
            this.SignUpButton.FillColor = System.Drawing.Color.Transparent;
            this.SignUpButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpButton.ForeColor = System.Drawing.Color.White;
            this.SignUpButton.HoverState.Parent = this.SignUpButton;
            this.SignUpButton.Location = new System.Drawing.Point(392, 455);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.ShadowDecoration.Parent = this.SignUpButton;
            this.SignUpButton.Size = new System.Drawing.Size(111, 27);
            this.SignUpButton.TabIndex = 8;
            this.SignUpButton.Text = "SIGN UP";
            this.SignUpButton.UseTransparentBackground = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Transparent;
            this.LoginButton.CheckedState.Parent = this.LoginButton;
            this.LoginButton.CustomImages.Parent = this.LoginButton;
            this.LoginButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LoginButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LoginButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoginButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LoginButton.DisabledState.Parent = this.LoginButton;
            this.LoginButton.FillColor = System.Drawing.Color.DarkCyan;
            this.LoginButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.HoverState.Parent = this.LoginButton;
            this.LoginButton.Location = new System.Drawing.Point(392, 413);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.ShadowDecoration.Parent = this.LoginButton;
            this.LoginButton.Size = new System.Drawing.Size(111, 36);
            this.LoginButton.TabIndex = 6;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseTransparentBackground = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Soccer_Management_Premier_League.Properties.Resources.logopl;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 516);
            this.Controls.Add(this.ChooseUser);
            this.Controls.Add(this.ForgotPass);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.PassCheck);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PassPanel);
            this.Controls.Add(this.UserPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Premier League Manager";
            this.UserPanel.ResumeLayout(false);
            this.PassPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox ChooseUser;
        private Guna.UI2.WinForms.Guna2TextBox UserTextbox;
        private System.Windows.Forms.FlowLayoutPanel UserPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel UserLabel;
        private Guna.UI2.WinForms.Guna2TextBox PassTextbox;
        private System.Windows.Forms.FlowLayoutPanel PassPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel PassLabel;
        private Guna.UI2.WinForms.Guna2Button ForgotPass;
        private Guna.UI2.WinForms.Guna2CheckBox PassCheck;
        private Guna.UI2.WinForms.Guna2Button SignUpButton;
        private Guna.UI2.WinForms.Guna2Button LoginButton;
    }



}

