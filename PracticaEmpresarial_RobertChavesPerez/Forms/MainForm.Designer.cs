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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opetationsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1143, 661);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitItem,
            this.inventoryItem,
            this.suppliersItem,
            this.opetationsItem,
            this.clientsItem,
            this.logsItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1143, 40);
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
            // suppliersItem
            // 
            this.suppliersItem.Name = "suppliersItem";
            this.suppliersItem.Size = new System.Drawing.Size(136, 36);
            this.suppliersItem.Text = "Proveedores";
            this.suppliersItem.Click += new System.EventHandler(this.suppliersItem_Click);
            // 
            // opetationsItem
            // 
            this.opetationsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.devolucionesToolStripMenuItem});
            this.opetationsItem.Name = "opetationsItem";
            this.opetationsItem.Size = new System.Drawing.Size(134, 36);
            this.opetationsItem.Text = "Operaciones";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // devolucionesToolStripMenuItem
            // 
            this.devolucionesToolStripMenuItem.Name = "devolucionesToolStripMenuItem";
            this.devolucionesToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.devolucionesToolStripMenuItem.Text = "Devoluciones";
            // 
            // clientsItem
            // 
            this.clientsItem.Name = "clientsItem";
            this.clientsItem.Size = new System.Drawing.Size(93, 36);
            this.clientsItem.Text = "Clientes";
            this.clientsItem.Click += new System.EventHandler(this.clientsItem_Click);
            // 
            // logsItem
            // 
            this.logsItem.Name = "logsItem";
            this.logsItem.Size = new System.Drawing.Size(105, 36);
            this.logsItem.Text = "Bitacoras";
            this.logsItem.Click += new System.EventHandler(this.logsItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1143, 701);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem inventoryItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersItem;
        private System.Windows.Forms.ToolStripMenuItem opetationsItem;
        private System.Windows.Forms.ToolStripMenuItem clientsItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
    }
}