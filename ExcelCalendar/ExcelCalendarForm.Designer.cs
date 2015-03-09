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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelCalendarForm));
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.weekComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.yearUpDown = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.feastCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.holidayCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.weekCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.generateExcel = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayout.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            resources.ApplyResources(this.tableLayout, "tableLayout");
            this.tableLayout.Controls.Add(this.progressBar, 0, 7);
            this.tableLayout.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayout.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayout.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayout.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayout.Controls.Add(this.generateExcel, 0, 6);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayout_Paint);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Maximum = 372;
            this.progressBar.Name = "progressBar";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.weekComboBox, 1, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // weekComboBox
            // 
            resources.ApplyResources(this.weekComboBox, "weekComboBox");
            this.weekComboBox.FormattingEnabled = true;
            this.weekComboBox.Items.AddRange(new object[] {
            resources.GetString("weekComboBox.Items"),
            resources.GetString("weekComboBox.Items1")});
            this.weekComboBox.Name = "weekComboBox";
            this.weekComboBox.SelectedIndexChanged += new System.EventHandler(this.weekComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.yearUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            this.label.Click += new System.EventHandler(this.label1_Click);
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
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.holidayCheckBox, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // holidayCheckBox
            // 
            resources.ApplyResources(this.holidayCheckBox, "holidayCheckBox");
            this.holidayCheckBox.Name = "holidayCheckBox";
            this.holidayCheckBox.UseVisualStyleBackColor = true;
            this.holidayCheckBox.CheckedChanged += new System.EventHandler(this.holidayCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.weekCheckBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // weekCheckBox
            // 
            resources.ApplyResources(this.weekCheckBox, "weekCheckBox");
            this.weekCheckBox.Name = "weekCheckBox";
            this.weekCheckBox.UseVisualStyleBackColor = true;
            this.weekCheckBox.CheckedChanged += new System.EventHandler(this.weekCheckBox_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // generateExcel
            // 
            resources.ApplyResources(this.generateExcel, "generateExcel");
            this.generateExcel.Name = "generateExcel";
            this.generateExcel.UseVisualStyleBackColor = true;
            this.generateExcel.Click += new System.EventHandler(this.generateExcel_Click);
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
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
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.NumericUpDown yearUpDown;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox feastCheckBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox holidayCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox weekComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox weekCheckBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button generateExcel;
    }
}

