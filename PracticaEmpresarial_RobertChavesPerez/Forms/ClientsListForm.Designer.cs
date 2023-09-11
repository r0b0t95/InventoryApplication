namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class ClientsListForm
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
            this.cbActivos = new System.Windows.Forms.CheckBox();
            this.lblClientsList = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.CclientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CclientTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CclientEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // cbActivos
            // 
            this.cbActivos.AutoSize = true;
            this.cbActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActivos.ForeColor = System.Drawing.Color.Gray;
            this.cbActivos.Location = new System.Drawing.Point(717, 109);
            this.cbActivos.Name = "cbActivos";
            this.cbActivos.Size = new System.Drawing.Size(82, 36);
            this.cbActivos.TabIndex = 33;
            this.cbActivos.Text = "Clientes\r\nActivos";
            this.cbActivos.UseVisualStyleBackColor = true;
            // 
            // lblClientsList
            // 
            this.lblClientsList.AutoSize = true;
            this.lblClientsList.Font = new System.Drawing.Font("Papyrus", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientsList.ForeColor = System.Drawing.Color.Gray;
            this.lblClientsList.Location = new System.Drawing.Point(485, 39);
            this.lblClientsList.Name = "lblClientsList";
            this.lblClientsList.Size = new System.Drawing.Size(136, 46);
            this.lblClientsList.TabIndex = 32;
            this.lblClientsList.Text = "Clientes";
            this.lblClientsList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(123)))), ((int)(((byte)(19)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSelect.Location = new System.Drawing.Point(764, 673);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(324, 54);
            this.btnSelect.TabIndex = 31;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CclientName,
            this.CclientTel,
            this.CclientEmail});
            this.dgvList.Location = new System.Drawing.Point(71, 199);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1017, 445);
            this.dgvList.TabIndex = 30;
            // 
            // CclientName
            // 
            this.CclientName.DataPropertyName = "clientName";
            this.CclientName.HeaderText = "Nombre";
            this.CclientName.Name = "CclientName";
            this.CclientName.ReadOnly = true;
            // 
            // CclientTel
            // 
            this.CclientTel.DataPropertyName = "clientTel";
            this.CclientTel.HeaderText = "Tel";
            this.CclientTel.Name = "CclientTel";
            this.CclientTel.ReadOnly = true;
            // 
            // CclientEmail
            // 
            this.CclientEmail.DataPropertyName = "clientEmail";
            this.CclientEmail.HeaderText = "Correo";
            this.CclientEmail.Name = "CclientEmail";
            this.CclientEmail.ReadOnly = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(1)))), ((int)(((byte)(16)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.Location = new System.Drawing.Point(71, 673);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(324, 54);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(131)))), ((int)(((byte)(237)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.Location = new System.Drawing.Point(419, 673);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(324, 54);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Agregar Cliente";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Silver;
            this.txtSearch.Location = new System.Drawing.Point(315, 109);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 47);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ClientsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1154, 774);
            this.Controls.Add(this.cbActivos);
            this.Controls.Add(this.lblClientsList);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientsListForm";
            this.Text = "ClientsListForm";
            this.Load += new System.EventHandler(this.ClientsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbActivos;
        private System.Windows.Forms.Label lblClientsList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CclientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CclientTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CclientEmail;
    }
}