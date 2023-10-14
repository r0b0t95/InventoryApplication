namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class LoginForm
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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.lblPolicies = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.AutoEllipsis = true;
            this.btnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(121)))), ((int)(((byte)(237)))));
            this.btnLogIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLogIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnLogIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogIn.Location = new System.Drawing.Point(69, 354);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(366, 54);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "Entrar";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.Location = new System.Drawing.Point(62, 120);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(366, 47);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "Nombre de usuario";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Location = new System.Drawing.Point(62, 183);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(366, 47);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Contraseña";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.ForeColor = System.Drawing.Color.Gray;
            this.cbShowPassword.Location = new System.Drawing.Point(57, 245);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(80, 30);
            this.cbShowPassword.TabIndex = 5;
            this.cbShowPassword.Text = "Mostrar\r\nContraseña\r\n";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.cbShowPassword_CheckedChanged);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.ForeColor = System.Drawing.Color.Gray;
            this.lblForgotPassword.Location = new System.Drawing.Point(304, 253);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(131, 13);
            this.lblForgotPassword.TabIndex = 7;
            this.lblForgotPassword.Text = "Olvido la contraseña?";
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // lblPolicies
            // 
            this.lblPolicies.AutoSize = true;
            this.lblPolicies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPolicies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPolicies.ForeColor = System.Drawing.Color.White;
            this.lblPolicies.Location = new System.Drawing.Point(175, 514);
            this.lblPolicies.Name = "lblPolicies";
            this.lblPolicies.Size = new System.Drawing.Size(129, 15);
            this.lblPolicies.TabIndex = 12;
            this.lblPolicies.Text = "Politicas de privacidad";
            this.lblPolicies.Click += new System.EventHandler(this.lblPolicies_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Papyrus", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Gray;
            this.lblLogo.Location = new System.Drawing.Point(147, 9);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(207, 92);
            this.lblLogo.TabIndex = 13;
            this.lblLogo.Text = "Repuestos\r\nSanta Eulalia";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(1)))), ((int)(((byte)(16)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.Location = new System.Drawing.Point(69, 434);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(366, 54);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(489, 592);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblPolicies);
            this.Controls.Add(this.lblForgotPassword);
            this.Controls.Add(this.cbShowPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Label lblPolicies;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnExit;
    }
}