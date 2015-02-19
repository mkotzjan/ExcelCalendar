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
            this.saveExcel = new System.Windows.Forms.SaveFileDialog();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateExcel
            // 
            resources.ApplyResources(this.generateExcel, "generateExcel");
            this.generateExcel.Name = "generateExcel";
            this.generateExcel.UseVisualStyleBackColor = true;
            // 
            // tableLayout
            // 
            resources.ApplyResources(this.tableLayout, "tableLayout");
            this.tableLayout.Controls.Add(this.generateExcel, 0, 1);
            this.tableLayout.Name = "tableLayout";
            // 
            // saveExcel
            // 
            resources.ApplyResources(this.saveExcel, "saveExcel");
            this.saveExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // ExcelCalendarForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Name = "ExcelCalendarForm";
            this.Load += new System.EventHandler(this.ExcelCalendarForm_Load);
            this.tableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateExcel;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.SaveFileDialog saveExcel;
    }
}

