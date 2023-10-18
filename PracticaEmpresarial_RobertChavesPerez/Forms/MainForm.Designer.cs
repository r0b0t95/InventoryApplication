namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Options = new System.Windows.Forms.ToolStripMenuItem();
            this.logsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Ccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CproductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Citem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ccant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblSeller = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.btnSearchClient = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblCant = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitItem,
            this.inventoryItem,
            this.Options,
            this.ventasToolStripMenuItem});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1395, 40);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "mainMenu";
            // 
            // exitItem
            // 
            this.exitItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.exitItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitItem.ForeColor = System.Drawing.Color.Black;
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(76, 36);
            this.exitItem.Text = "Salir";
            this.exitItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // inventoryItem
            // 
            this.inventoryItem.Name = "inventoryItem";
            this.inventoryItem.Size = new System.Drawing.Size(116, 36);
            this.inventoryItem.Text = "Inventario";
            this.inventoryItem.Click += new System.EventHandler(this.inventoryItem_Click);
            // 
            // Options
            // 
            this.Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsItem,
            this.usersItem,
            this.changePasswordItem});
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(106, 36);
            this.Options.Text = "Opciones";
            this.Options.Click += new System.EventHandler(this.logsItem_Click);
            // 
            // logsItem
            // 
            this.logsItem.Name = "logsItem";
            this.logsItem.Size = new System.Drawing.Size(264, 30);
            this.logsItem.Text = "Bitacora";
            this.logsItem.Click += new System.EventHandler(this.logsItem_Click_1);
            // 
            // usersItem
            // 
            this.usersItem.Name = "usersItem";
            this.usersItem.Size = new System.Drawing.Size(264, 30);
            this.usersItem.Text = "Usuarios";
            this.usersItem.Click += new System.EventHandler(this.usersItem_Click);
            // 
            // changePasswordItem
            // 
            this.changePasswordItem.Name = "changePasswordItem";
            this.changePasswordItem.Size = new System.Drawing.Size(264, 30);
            this.changePasswordItem.Text = "Cambiar Contraseña";
            this.changePasswordItem.Click += new System.EventHandler(this.changePasswordItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(83, 36);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ccode,
            this.CproductId,
            this.Citem,
            this.Ccant,
            this.Cprice});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.Location = new System.Drawing.Point(44, 225);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1306, 394);
            this.dgvList.TabIndex = 34;
            this.dgvList.VirtualMode = true;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // Ccode
            // 
            this.Ccode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ccode.DataPropertyName = "code";
            this.Ccode.HeaderText = "COD";
            this.Ccode.Name = "Ccode";
            this.Ccode.ReadOnly = true;
            this.Ccode.Width = 79;
            // 
            // CproductId
            // 
            this.CproductId.DataPropertyName = "productId";
            this.CproductId.HeaderText = "ID";
            this.CproductId.Name = "CproductId";
            this.CproductId.ReadOnly = true;
            this.CproductId.Visible = false;
            // 
            // Citem
            // 
            this.Citem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Citem.DataPropertyName = "item";
            this.Citem.HeaderText = "ITEM";
            this.Citem.Name = "Citem";
            this.Citem.ReadOnly = true;
            // 
            // Ccant
            // 
            this.Ccant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ccant.DataPropertyName = "cant";
            this.Ccant.HeaderText = "CANTIDAD";
            this.Ccant.Name = "Ccant";
            this.Ccant.ReadOnly = true;
            this.Ccant.Width = 138;
            // 
            // Cprice
            // 
            this.Cprice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cprice.DataPropertyName = "price";
            this.Cprice.HeaderText = "PRECIO";
            this.Cprice.Name = "Cprice";
            this.Cprice.ReadOnly = true;
            this.Cprice.Width = 111;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Purple;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.Location = new System.Drawing.Point(1026, 734);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(324, 54);
            this.btnAdd.TabIndex = 32;
            this.btnAdd.Text = "Crear Venta";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeller.ForeColor = System.Drawing.Color.Gray;
            this.lblSeller.Location = new System.Drawing.Point(59, 764);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(97, 20);
            this.lblSeller.TabIndex = 36;
            this.lblSeller.Text = "Vendedor: ";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.ForeColor = System.Drawing.Color.Gray;
            this.lblClientName.Location = new System.Drawing.Point(231, 98);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(129, 20);
            this.lblClientName.TabIndex = 38;
            this.lblClientName.Text = "Nombre cliente";
            // 
            // txtClientName
            // 
            this.txtClientName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.ForeColor = System.Drawing.Color.Silver;
            this.txtClientName.Location = new System.Drawing.Point(235, 119);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.ReadOnly = true;
            this.txtClientName.Size = new System.Drawing.Size(385, 24);
            this.txtClientName.TabIndex = 39;
            this.txtClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(123)))), ((int)(((byte)(19)))));
            this.btnSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchClient.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearchClient.Location = new System.Drawing.Point(44, 62);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(84, 33);
            this.btnSearchClient.TabIndex = 40;
            this.btnSearchClient.Text = "Buscar";
            this.btnSearchClient.UseVisualStyleBackColor = false;
            this.btnSearchClient.Click += new System.EventHandler(this.btnSearchClient_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(1)))), ((int)(((byte)(16)))));
            this.btnRemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProduct.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemoveProduct.Location = new System.Drawing.Point(400, 186);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(172, 33);
            this.btnRemoveProduct.TabIndex = 41;
            this.btnRemoveProduct.Text = "Quitar Producto x";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Silver;
            this.txtUser.Location = new System.Drawing.Point(150, 762);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(319, 26);
            this.txtUser.TabIndex = 42;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientId.ForeColor = System.Drawing.Color.Gray;
            this.lblClientId.Location = new System.Drawing.Point(40, 98);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(148, 20);
            this.lblClientId.TabIndex = 43;
            this.lblClientId.Text = "Codigo de cliente";
            // 
            // txtClientId
            // 
            this.txtClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientId.ForeColor = System.Drawing.Color.Silver;
            this.txtClientId.Location = new System.Drawing.Point(44, 119);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.ReadOnly = true;
            this.txtClientId.Size = new System.Drawing.Size(172, 24);
            this.txtClientId.TabIndex = 44;
            this.txtClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(131)))), ((int)(((byte)(237)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddProduct.Location = new System.Drawing.Point(44, 186);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(172, 33);
            this.btnAddProduct.TabIndex = 45;
            this.btnAddProduct.Text = "Agregar Producto +";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.btnUpdateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdateProduct.Location = new System.Drawing.Point(222, 186);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(172, 33);
            this.btnUpdateProduct.TabIndex = 46;
            this.btnUpdateProduct.Text = "Modificar Cantidad -";
            this.btnUpdateProduct.UseVisualStyleBackColor = false;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.Silver;
            this.txtSubTotal.Location = new System.Drawing.Point(44, 660);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(273, 38);
            this.txtSubTotal.TabIndex = 48;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTotal.Location = new System.Drawing.Point(135, 637);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(101, 20);
            this.lblSubTotal.TabIndex = 47;
            this.lblSubTotal.Text = "SUBTOTAL";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Gray;
            this.lblDiscount.Location = new System.Drawing.Point(470, 637);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(118, 20);
            this.lblDiscount.TabIndex = 49;
            this.lblDiscount.Text = "DESCUENTO";
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.lblCant.Location = new System.Drawing.Point(1022, 177);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(81, 40);
            this.lblCant.TabIndex = 50;
            this.lblCant.Text = "Nueva\r\nCantidad\r\n";
            this.lblCant.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTotal.Location = new System.Drawing.Point(1177, 635);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(77, 24);
            this.lblTotal.TabIndex = 51;
            this.lblTotal.Text = "TOTAL";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Silver;
            this.txtDiscount.Location = new System.Drawing.Point(393, 660);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(273, 38);
            this.txtDiscount.TabIndex = 52;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCant
            // 
            this.txtCant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.txtCant.Location = new System.Drawing.Point(1109, 179);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(106, 38);
            this.txtCant.TabIndex = 53;
            this.txtCant.Text = "1";
            this.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCant.Visible = false;
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Yellow;
            this.txtTotal.Location = new System.Drawing.Point(1077, 660);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(273, 38);
            this.txtTotal.TabIndex = 54;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1395, 815);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.btnSearchClient);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem inventoryItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem Options;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblClientId;
        public System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.ToolStripMenuItem logsItem;
        private System.Windows.Forms.ToolStripMenuItem usersItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        public System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.TextBox txtDiscount;
        public System.Windows.Forms.TextBox txtCant;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CproductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Citem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ccant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cprice;
    }
}