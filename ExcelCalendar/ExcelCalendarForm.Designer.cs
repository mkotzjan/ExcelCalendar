namespace ExcelCalendar
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
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).BeginInit();
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
            this.tableLayout.Controls.Add(this.yearUpDown, 0, 0);
            this.tableLayout.Controls.Add(this.generateExcel, 0, 1);
            this.tableLayout.Name = "tableLayout";
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
            1980,
            0,
            0,
            0});
            this.yearUpDown.Name = "yearUpDown";
            this.yearUpDown.Value = new decimal(new int[] {
            Options.year,
            0,
            0,
            0});
            this.yearUpDown.ValueChanged += new System.EventHandler(this.yearUpDown_ValueChanged);
            // 
            // ExcelCalendarForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Name = "ExcelCalendarForm";
            this.Load += new System.EventHandler(this.ExcelCalendarForm_Load);
            this.tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateExcel;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.NumericUpDown yearUpDown;
    }
}

