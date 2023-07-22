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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.btnNewAccount = new System.Windows.Forms.Button();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.AutoEllipsis = true;
            this.btnLogIn.BackColor = System.Drawing.Color.Green;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogIn.Location = new System.Drawing.Point(50, 290);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(441, 40);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "Entrar";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(50, 111);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(441, 35);
            this.txtName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(50, 183);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(441, 35);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(50, 360);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(441, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbShowPassword.Location = new System.Drawing.Point(411, 224);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(80, 30);
            this.cbShowPassword.TabIndex = 5;
            this.cbShowPassword.Text = "Mostrar\r\nContraseña\r\n";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.cbShowPassword_CheckedChanged);
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNewAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAccount.Location = new System.Drawing.Point(50, 446);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.Size = new System.Drawing.Size(132, 36);
            this.btnNewAccount.TabIndex = 6;
            this.btnNewAccount.Text = "Crear nueva cuenta";
            this.btnNewAccount.UseVisualStyleBackColor = false;
            this.btnNewAccount.Click += new System.EventHandler(this.btnNewAccount_Click);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblForgotPassword.Location = new System.Drawing.Point(333, 456);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(158, 16);
            this.lblForgotPassword.TabIndex = 7;
            this.lblForgotPassword.Text = "Olvido la contraseña?";
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(237, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(539, 494);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblForgotPassword);
            this.Controls.Add(this.btnNewAccount);
            this.Controls.Add(this.cbShowPassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnLogIn);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.Button btnNewAccount;
        private System.Windows.Forms.Label lblForgotPassword;
        protected internal System.Windows.Forms.PictureBox pictureBox1;
    }
}