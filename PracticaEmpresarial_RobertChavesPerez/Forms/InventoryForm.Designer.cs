namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class InventoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCant = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.cbActivos = new System.Windows.Forms.CheckBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.btnAddCode = new System.Windows.Forms.Button();
            this.dgvCodeList = new System.Windows.Forms.DataGridView();
            this.CcodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.CpCodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CproductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CpCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ccant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CproductDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(1241, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 48);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnDelete.TabIndex = 40;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpdate.Location = new System.Drawing.Point(487, 776);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(200, 54);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCant
            // 
            this.txtCant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCant.ForeColor = System.Drawing.Color.Silver;
            this.txtCant.Location = new System.Drawing.Point(141, 651);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(393, 47);
            this.txtCant.TabIndex = 38;
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.Silver;
            this.txtPrice.Location = new System.Drawing.Point(141, 593);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(393, 47);
            this.txtPrice.TabIndex = 37;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblPrice.Location = new System.Drawing.Point(48, 602);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(66, 20);
            this.lblPrice.TabIndex = 36;
            this.lblPrice.Text = "Precio*";
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.ForeColor = System.Drawing.Color.Gray;
            this.lblCant.Location = new System.Drawing.Point(47, 660);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(88, 20);
            this.lblCant.TabIndex = 35;
            this.lblCant.Text = "Cantidad*";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(1)))), ((int)(((byte)(16)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.Location = new System.Drawing.Point(51, 776);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(201, 54);
            this.btnExit.TabIndex = 34;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(131)))), ((int)(((byte)(237)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Location = new System.Drawing.Point(268, 776);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 54);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.Color.Silver;
            this.txtCode.Location = new System.Drawing.Point(141, 535);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(393, 47);
            this.txtCode.TabIndex = 32;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Gray;
            this.lblCode.Location = new System.Drawing.Point(48, 545);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(72, 20);
            this.lblCode.TabIndex = 31;
            this.lblCode.Text = "Codigo*";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Papyrus", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTitle.Location = new System.Drawing.Point(590, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 55);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Inventario";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDetail
            // 
            this.txtDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.ForeColor = System.Drawing.Color.Silver;
            this.txtDetail.Location = new System.Drawing.Point(141, 709);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(762, 47);
            this.txtDetail.TabIndex = 41;
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.ForeColor = System.Drawing.Color.Gray;
            this.lblDetail.Location = new System.Drawing.Point(48, 719);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(73, 20);
            this.lblDetail.TabIndex = 42;
            this.lblDetail.Text = "Detalle*";
            // 
            // cbActivos
            // 
            this.cbActivos.AutoSize = true;
            this.cbActivos.Checked = true;
            this.cbActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActivos.ForeColor = System.Drawing.Color.Gray;
            this.cbActivos.Location = new System.Drawing.Point(842, 29);
            this.cbActivos.Name = "cbActivos";
            this.cbActivos.Size = new System.Drawing.Size(96, 36);
            this.cbActivos.TabIndex = 45;
            this.cbActivos.Text = "Productos\r\nActivos";
            this.cbActivos.UseVisualStyleBackColor = true;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CpCodeId,
            this.CproductId,
            this.CpCode,
            this.Ccant,
            this.Cprice,
            this.CproductDetail});
            this.dgvList.Location = new System.Drawing.Point(51, 94);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1249, 421);
            this.dgvList.TabIndex = 44;
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProduct.ForeColor = System.Drawing.Color.Silver;
            this.txtSearchProduct.Location = new System.Drawing.Point(141, 22);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(357, 47);
            this.txtSearchProduct.TabIndex = 43;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtSearchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCode.ForeColor = System.Drawing.Color.Silver;
            this.txtSearchCode.Location = new System.Drawing.Point(705, 535);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(198, 47);
            this.txtSearchCode.TabIndex = 46;
            this.txtSearchCode.TextChanged += new System.EventHandler(this.txtSearchCode_TextChanged);
            // 
            // btnAddCode
            // 
            this.btnAddCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(123)))), ((int)(((byte)(19)))));
            this.btnAddCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddCode.Location = new System.Drawing.Point(703, 776);
            this.btnAddCode.Name = "btnAddCode";
            this.btnAddCode.Size = new System.Drawing.Size(200, 54);
            this.btnAddCode.TabIndex = 47;
            this.btnAddCode.Text = "Agregar Codigo";
            this.btnAddCode.UseVisualStyleBackColor = false;
            this.btnAddCode.Click += new System.EventHandler(this.btnAddCode_Click);
            // 
            // dgvCodeList
            // 
            this.dgvCodeList.AllowUserToAddRows = false;
            this.dgvCodeList.AllowUserToDeleteRows = false;
            this.dgvCodeList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvCodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CcodeId,
            this.Ccode});
            this.dgvCodeList.Location = new System.Drawing.Point(925, 535);
            this.dgvCodeList.Name = "dgvCodeList";
            this.dgvCodeList.ReadOnly = true;
            this.dgvCodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodeList.Size = new System.Drawing.Size(375, 295);
            this.dgvCodeList.TabIndex = 48;
            this.dgvCodeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeList_CellClick);
            this.dgvCodeList.DoubleClick += new System.EventHandler(this.dgvCodeList_DoubleClick);
            // 
            // CcodeId
            // 
            this.CcodeId.DataPropertyName = "codeId";
            this.CcodeId.HeaderText = "Id";
            this.CcodeId.Name = "CcodeId";
            this.CcodeId.ReadOnly = true;
            this.CcodeId.Visible = false;
            // 
            // Ccode
            // 
            this.Ccode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ccode.DataPropertyName = "code";
            this.Ccode.HeaderText = "Codigo";
            this.Ccode.Name = "Ccode";
            this.Ccode.ReadOnly = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnRefresh.Location = new System.Drawing.Point(1035, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 54);
            this.btnRefresh.TabIndex = 49;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // CpCodeId
            // 
            this.CpCodeId.DataPropertyName = "pCodeId";
            this.CpCodeId.HeaderText = "IdCodigo";
            this.CpCodeId.Name = "CpCodeId";
            this.CpCodeId.ReadOnly = true;
            this.CpCodeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CpCodeId.Visible = false;
            // 
            // CproductId
            // 
            this.CproductId.DataPropertyName = "productId";
            this.CproductId.HeaderText = "productId";
            this.CproductId.Name = "CproductId";
            this.CproductId.ReadOnly = true;
            this.CproductId.Visible = false;
            // 
            // CpCode
            // 
            this.CpCode.DataPropertyName = "pCode";
            this.CpCode.HeaderText = "Codigo";
            this.CpCode.Name = "CpCode";
            this.CpCode.ReadOnly = true;
            // 
            // Ccant
            // 
            this.Ccant.DataPropertyName = "cant";
            this.Ccant.HeaderText = "Cantidad";
            this.Ccant.Name = "Ccant";
            this.Ccant.ReadOnly = true;
            // 
            // Cprice
            // 
            this.Cprice.DataPropertyName = "price";
            this.Cprice.HeaderText = "Precio";
            this.Cprice.Name = "Cprice";
            this.Cprice.ReadOnly = true;
            // 
            // CproductDetail
            // 
            this.CproductDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CproductDetail.DataPropertyName = "productDetail";
            this.CproductDetail.HeaderText = "Detalle";
            this.CproductDetail.Name = "CproductDetail";
            this.CproductDetail.ReadOnly = true;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1345, 852);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvCodeList);
            this.Controls.Add(this.btnAddCode);
            this.Controls.Add(this.txtSearchCode);
            this.Controls.Add(this.cbActivos);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtSearchProduct);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox txtCant;
        public System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.CheckBox cbActivos;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.Button btnAddCode;
        private System.Windows.Forms.DataGridView dgvCodeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CcodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ccode;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CpCodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CproductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CpCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ccant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CproductDetail;
    }
}