﻿namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    partial class Report
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
            this.crystalReportV1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportV1
            // 
            this.crystalReportV1.ActiveViewIndex = -1;
            this.crystalReportV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportV1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportV1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportV1.Name = "crystalReportV1";
            this.crystalReportV1.Size = new System.Drawing.Size(939, 626);
            this.crystalReportV1.TabIndex = 0;
            this.crystalReportV1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(939, 626);
            this.Controls.Add(this.crystalReportV1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportV1;
    }
}