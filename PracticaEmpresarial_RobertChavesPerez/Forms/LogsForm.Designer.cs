namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class LogsForm
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
            this.lblLogsList = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.fromDTPicker = new System.Windows.Forms.DateTimePicker();
            this.toDTPicker = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.CuserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClogDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogsList
            // 
            this.lblLogsList.AutoSize = true;
            this.lblLogsList.Font = new System.Drawing.Font("Papyrus", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogsList.ForeColor = System.Drawing.Color.Gray;
            this.lblLogsList.Location = new System.Drawing.Point(323, 40);
            this.lblLogsList.Name = "lblLogsList";
            this.lblLogsList.Size = new System.Drawing.Size(140, 46);
            this.lblLogsList.TabIndex = 36;
            this.lblLogsList.Text = "Bitacora";
            this.lblLogsList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CuserName,
            this.ClogDate,
            this.ClogDetail});
            this.dgvList.Location = new System.Drawing.Point(62, 224);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(682, 445);
            this.dgvList.TabIndex = 35;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Silver;
            this.txtSearch.Location = new System.Drawing.Point(62, 129);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(370, 47);
            this.txtSearch.TabIndex = 34;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // fromDTPicker
            // 
            this.fromDTPicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDTPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDTPicker.Location = new System.Drawing.Point(489, 129);
            this.fromDTPicker.Name = "fromDTPicker";
            this.fromDTPicker.Size = new System.Drawing.Size(255, 21);
            this.fromDTPicker.TabIndex = 37;
            this.fromDTPicker.ValueChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toDTPicker
            // 
            this.toDTPicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDTPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDTPicker.Location = new System.Drawing.Point(489, 184);
            this.toDTPicker.Name = "toDTPicker";
            this.toDTPicker.Size = new System.Drawing.Size(255, 21);
            this.toDTPicker.TabIndex = 38;
            this.toDTPicker.ValueChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.Gray;
            this.lblFrom.Location = new System.Drawing.Point(490, 108);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(107, 18);
            this.lblFrom.TabIndex = 39;
            this.lblFrom.Text = "Fecha Desde";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.Gray;
            this.lblTo.Location = new System.Drawing.Point(490, 163);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(103, 18);
            this.lblTo.TabIndex = 40;
            this.lblTo.Text = "Fecha Hasta";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.ForeColor = System.Drawing.Color.Gray;
            this.lblDetail.Location = new System.Drawing.Point(59, 108);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(60, 18);
            this.lblDetail.TabIndex = 41;
            this.lblDetail.Text = "Detalle";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(1)))), ((int)(((byte)(16)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.Location = new System.Drawing.Point(234, 701);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(324, 54);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // CuserName
            // 
            this.CuserName.DataPropertyName = "userName";
            this.CuserName.HeaderText = "Usuario";
            this.CuserName.Name = "CuserName";
            this.CuserName.ReadOnly = true;
            // 
            // ClogDate
            // 
            this.ClogDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClogDate.DataPropertyName = "logDate";
            this.ClogDate.HeaderText = "Fecha";
            this.ClogDate.Name = "ClogDate";
            this.ClogDate.ReadOnly = true;
            this.ClogDate.Width = 150;
            // 
            // ClogDetail
            // 
            this.ClogDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClogDetail.DataPropertyName = "logDetail";
            this.ClogDetail.HeaderText = "Detalle";
            this.ClogDetail.Name = "ClogDetail";
            this.ClogDetail.ReadOnly = true;
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(803, 808);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.toDTPicker);
            this.Controls.Add(this.fromDTPicker);
            this.Controls.Add(this.lblLogsList);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogsForm";
            this.Load += new System.EventHandler(this.LogsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogsList;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker fromDTPicker;
        private System.Windows.Forms.DateTimePicker toDTPicker;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClogDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClogDetail;
    }
}