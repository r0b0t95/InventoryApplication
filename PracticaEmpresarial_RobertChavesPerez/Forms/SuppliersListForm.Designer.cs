namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class SuppliersListForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.CsupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsupplierTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsupplierEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsupplierDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblSuppliersList = new System.Windows.Forms.Label();
            this.cbActivos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Silver;
            this.txtSearch.Location = new System.Drawing.Point(315, 109);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 47);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Agregar Proveedor";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CsupplierName,
            this.CsupplierId,
            this.CsupplierTel,
            this.CsupplierEmail,
            this.CsupplierDescription});
            this.dgvList.Location = new System.Drawing.Point(71, 199);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1017, 445);
            this.dgvList.TabIndex = 23;
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            // 
            // CsupplierName
            // 
            this.CsupplierName.DataPropertyName = "supplierName";
            this.CsupplierName.HeaderText = "Nombre";
            this.CsupplierName.Name = "CsupplierName";
            this.CsupplierName.ReadOnly = true;
            // 
            // CsupplierId
            // 
            this.CsupplierId.DataPropertyName = "supplierId";
            this.CsupplierId.HeaderText = "Id";
            this.CsupplierId.Name = "CsupplierId";
            this.CsupplierId.ReadOnly = true;
            this.CsupplierId.Visible = false;
            // 
            // CsupplierTel
            // 
            this.CsupplierTel.DataPropertyName = "supplierTel";
            this.CsupplierTel.HeaderText = "Tel";
            this.CsupplierTel.Name = "CsupplierTel";
            this.CsupplierTel.ReadOnly = true;
            // 
            // CsupplierEmail
            // 
            this.CsupplierEmail.DataPropertyName = "supplierEmail";
            this.CsupplierEmail.HeaderText = "Correo";
            this.CsupplierEmail.Name = "CsupplierEmail";
            this.CsupplierEmail.ReadOnly = true;
            // 
            // CsupplierDescription
            // 
            this.CsupplierDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CsupplierDescription.DataPropertyName = "supplierDescription";
            this.CsupplierDescription.HeaderText = "Descripcion";
            this.CsupplierDescription.Name = "CsupplierDescription";
            this.CsupplierDescription.ReadOnly = true;
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
            this.btnSelect.TabIndex = 24;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // lblSuppliersList
            // 
            this.lblSuppliersList.AutoSize = true;
            this.lblSuppliersList.Font = new System.Drawing.Font("Papyrus", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppliersList.ForeColor = System.Drawing.Color.Gray;
            this.lblSuppliersList.Location = new System.Drawing.Point(485, 39);
            this.lblSuppliersList.Name = "lblSuppliersList";
            this.lblSuppliersList.Size = new System.Drawing.Size(187, 46);
            this.lblSuppliersList.TabIndex = 25;
            this.lblSuppliersList.Text = "Proveedores";
            this.lblSuppliersList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbActivos
            // 
            this.cbActivos.AutoSize = true;
            this.cbActivos.Checked = true;
            this.cbActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActivos.ForeColor = System.Drawing.Color.Gray;
            this.cbActivos.Location = new System.Drawing.Point(717, 109);
            this.cbActivos.Name = "cbActivos";
            this.cbActivos.Size = new System.Drawing.Size(116, 36);
            this.cbActivos.TabIndex = 26;
            this.cbActivos.Text = "Proveedores\r\nActivos";
            this.cbActivos.UseVisualStyleBackColor = true;
            this.cbActivos.CheckedChanged += new System.EventHandler(this.cbActivos_CheckedChanged);
            // 
            // SuppliersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1154, 774);
            this.Controls.Add(this.cbActivos);
            this.Controls.Add(this.lblSuppliersList);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SuppliersListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuppliersListForm";
            this.Load += new System.EventHandler(this.SuppliersListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblSuppliersList;
        private System.Windows.Forms.CheckBox cbActivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsupplierTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsupplierEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsupplierDescription;
    }
}