﻿namespace ExcelCalendar
{
    partial class ExcelCalendarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelCalendarForm));
            this.generateExcel = new System.Windows.Forms.Button();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.yearUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.feastCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateExcel
            // 
            resources.ApplyResources(this.generateExcel, "generateExcel");
            this.generateExcel.Name = "generateExcel";
            this.generateExcel.UseVisualStyleBackColor = true;
            this.generateExcel.Click += new System.EventHandler(this.generateExcel_Click);
            // 
            // tableLayout
            // 
            resources.ApplyResources(this.tableLayout, "tableLayout");
            this.tableLayout.Controls.Add(this.progressBar, 0, 4);
            this.tableLayout.Controls.Add(this.generateExcel, 0, 3);
            this.tableLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayout.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayout_Paint);
            // 
            // yearUpDown
            // 
            resources.ApplyResources(this.yearUpDown, "yearUpDown");
            this.yearUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.yearUpDown.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.yearUpDown.Name = "yearUpDown";
            this.yearUpDown.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.yearUpDown.ValueChanged += new System.EventHandler(this.yearUpDown_ValueChanged);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Maximum = 372;
            this.progressBar.Name = "progressBar";
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.yearUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.feastCheckBox, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // feastCheckBox
            // 
            resources.ApplyResources(this.feastCheckBox, "feastCheckBox");
            this.feastCheckBox.Name = "feastCheckBox";
            this.feastCheckBox.UseVisualStyleBackColor = true;
            this.feastCheckBox.CheckedChanged += new System.EventHandler(this.feastCheckBox_CheckedChanged);
            // 
            // ExcelCalendarForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExcelCalendarForm";
            this.Load += new System.EventHandler(this.ExcelCalendarForm_Load);
            this.tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateExcel;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.NumericUpDown yearUpDown;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox feastCheckBox;
    }
}

